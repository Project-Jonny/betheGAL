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

        rigidBody2D.velocity = new Vector2(speed, rigidBody2D.velocity.y);

    }

    public void RightDown()
    {
        animator.SetBool("run", true);
        right = true;
    }

    public void RightUp()
    {
        animator.SetBool("run", false);
        right = false;
    }

    public void LeftDown()
    {
        animator.SetBool("run", true);
        left = true;
    }

    public void LeftUp()
    {
        animator.SetBool("run", false);
        left = false;
    }

    // 押したとき
    public void DownJumpButton()
    {
        SoundManager.instance.PlaySE(2);
        downJumpButton = true; // こいつは1フレームでfalseにする
        onJumpButton = true;   // こいつはボタンを離したときにfalseにする
    }
    // はなしたとき
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

    public void OnCompleteAnimation()
    {
        this.gameObject.SetActive(false);
    }

    void Restart()
    {
        if (GameData.instance.PaonMode == false)
        {
            GameData.instance.Life = GameData.instance.Life - 1;
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
