using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Animator animator;

    float speed = 0;
    float JumpPower = 10f;

    bool right;
    bool left;

    bool gameFlag = true;

    bool isJumping;

    float jumpTimeCounter;
    public float jumpTime;

    public static int DeathCount = 0;

    [SerializeField] string nextScene;

    public Groundcheck ground;
    bool isGround;

    bool downJumpButton; // ボタンをおした（Input.GetKeyDown(KeyCode.Space)のかわり）
    bool onJumpButton; // ボタンをおしている（Input.GetKey(KeyCode.Space)のかわり）

    public LifeGauge lifeGauge;

    // 踏みつけ判定の高さの割合(%)
    public float stepOnRate;

    // BoxColliderの取得
    private BoxCollider2D boxcol;

    // MoveObj
    private MoveObject moveObj = null;

    public enum MOVE_DIRECTION
    {
        STOP,
        LEFT,
        RIGHT,
    }
    MOVE_DIRECTION moveDirection = MOVE_DIRECTION.STOP;

    void Start()
    {
        string SceneName = SceneManager.GetActiveScene().name;
        SoundManager.instance.PlayBGM(SceneName);
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxcol = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!gameFlag)
        {
            return;
        }

        if (GameData.instance.Life == 0)
        {
            GameOver();
        }

        if (isGround && downJumpButton)
        {
            downJumpButton = false; // 押したかどうかだからすぐにfalse 
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rigidBody2D.AddForce(Vector2.up * JumpPower);
            //Debug.Log("押した");
        }

        if (onJumpButton && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rigidBody2D.velocity = Vector2.up * JumpPower;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            //Debug.Log("押し続けている");
        }

        if (right)
        {
            moveDirection = MOVE_DIRECTION.RIGHT;
        }
        else if (left)
        {
            moveDirection = MOVE_DIRECTION.LEFT;
        }
        else
        {
            moveDirection = MOVE_DIRECTION.STOP;
        }
    }

    private void FixedUpdate()
    {
        if (!gameFlag)
        {
            return;
        }

        isGround = ground.IsGround();

        switch (moveDirection)
        {
            case MOVE_DIRECTION.STOP:
                speed = 0;
                break;

            case MOVE_DIRECTION.RIGHT:
                speed = 7;
                transform.localScale = new Vector3(1, 1, 1);
                break;

            case MOVE_DIRECTION.LEFT:
                speed = -7;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }

        //rigidBody2D.velocity = new Vector2(speed, rigidBody2D.velocity.y);

        //移動速度を設定
        Vector2 addVelocity = Vector2.zero;
        if (moveObj != null)
        {
            addVelocity = moveObj.GetVelocity();
        }
        rigidBody2D.velocity = new Vector2(speed, rigidBody2D.velocity.y) + addVelocity;

    }

    // 右の移動ボタンを押した時
    public void RightDown()
    {
        animator.SetBool("run", true);
        right = true;
    }

    // 右の移動ボタンを離した時
    public void RightUp()
    {
        animator.SetBool("run", false);
        right = false;
    }

    // 左の移動ボタンを押した時
    public void LeftDown()
    {
        animator.SetBool("run", true);
        left = true;
    }

    // 左の移動ボタンを離した時
    public void LeftUp()
    {
        animator.SetBool("run", false);
        left = false;
    }

    // ジャンプボタンを押した時
    public void DownJumpButton()
    {
        SoundManager.instance.PlaySE(2);
        downJumpButton = true; // こいつは1フレームでfalseにする
        onJumpButton = true;   // こいつはボタンを離したときにfalseにする
    }
    // ジャンプボタンを離した時
    public void UpJumpButton()
    {
        onJumpButton = false;
        isJumping = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameFlag)
        {
            return;
        }
        if (collision.gameObject.tag == "Trap")
        {
            SoundManager.instance.PlaySE(4);
            if (GameData.instance.PaonMode == false)
            {
                lifeGauge.SetLifeGauge2(1);
            }
            DeathCount++;
            BoxCollider2D Bcoli = GetComponent<BoxCollider2D>();
            Destroy(Bcoli);
            rigidBody2D.gravityScale = 0;
            rigidBody2D.velocity = new Vector2(0, 0);
            gameFlag = false;
            animator.SetTrigger("Death");
            Invoke("Restart", 0.8f);
        }

        else if (collision.gameObject.tag == "toNext")
        {
            SceneManager.LoadScene(nextScene);
        }

        else if (collision.gameObject.tag == "Boss")
        {
            SoundManager.instance.PlaySE(4);
            if (GameData.instance.PaonMode == false)
            {
                lifeGauge.SetLifeGauge2(1);
            }
            DeathCount++;
            BoxCollider2D Bcoli = GetComponent<BoxCollider2D>();
            Destroy(Bcoli);
            rigidBody2D.gravityScale = 0;
            rigidBody2D.velocity = new Vector2(0, 0);
            gameFlag = false;
            animator.SetTrigger("Death");
            Invoke("Restart", 0.8f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //動く床
        if (collision.collider.tag == "MoveFloor")
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (boxcol.size.y * (stepOnRate / 100f));
            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (boxcol.size.y / 2f) + stepOnHeight;
            foreach (ContactPoint2D p in collision.contacts)
            {
                //動く床に乗っている
                if (p.point.y > judgePos)
                {
                    moveObj = collision.gameObject.GetComponent<MoveObject>();
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "MoveFloor")
        {
            //動く床から離れた
            moveObj = null;
        }
    }

    public void OnCompleteAnimation()
    {
        this.gameObject.SetActive(false);
    }

    void Restart()
    {
        if (GameData.instance.PaonMode == false)
        {
            GameData.instance.Life -= 1;
        }

        if (GameData.instance.Life == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            string nowScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(nowScene);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    bool IsGround()
    {
        return false;
    }
}
