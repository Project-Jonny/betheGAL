using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyingPlayer : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Animator animator;

    float speed = 2f;
    public float JumpPower;

    bool gameFlag = true;

    bool isJumping;

    float jumpTimeCounter;
    public float jumpTime;

    [SerializeField] string nextScene;

    bool downJumpButton; // ボタンをおした（Input.GetKeyDown(KeyCode.Space)のかわり）
    bool onJumpButton; // ボタンをおしている（Input.GetKey(KeyCode.Space)のかわり）

    public LifeGauge lifeGauge;

    public GameObject[] wing;

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

        if (downJumpButton)
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
    }

    private void FixedUpdate()
    {
        if (!gameFlag)
        {
            return;
        }

        rigidBody2D.velocity = new Vector2(speed, rigidBody2D.velocity.y);
    }

    // 押したとき
    public void DownJumpButton()
    {
        SoundManager.instance.PlaySE(2);
        downJumpButton = true; // こいつは1フレームでfalseにする
        onJumpButton = true;   // こいつはボタンを離したときにfalseにする
        wing[0].SetActive(true);
        wing[1].SetActive(false);
    }
    // はなしたとき
    public void UpJumpButton()
    {
        onJumpButton = false;
        isJumping = false;
        wing[0].SetActive(false);
        wing[1].SetActive(true);
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
            Player.DeathCount++;
            wing[0].SetActive(false);
            wing[1].SetActive(false);
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
}