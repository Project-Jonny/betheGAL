using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoEnemy : MonoBehaviour
{
    private bool isReachTargetPosition;
    private Vector3 targetPosition;

    public EnemyLife enemyLife;

    public float X_MIN_MOVE_RANGE = -11f;
    public float X_MAX_MOVE_RANGE = 12f;
    public float Y_MIN_MOVE_RANGE = 0f;
    public float Y_MAX_MOVE_RANGE = 8f;

    public float SPEED = 0.05f;

    private BulletPool _pool;
    private BulletPool SecondPool;

    public GameObject player;

    int count = 0;

    void Start()
    {
        _pool = GameObject.Find("BulletPool").GetComponent<BulletPool>();
        SecondPool = GameObject.Find("Pool").GetComponent<BulletPool>();
        player = GameObject.Find("Player");
        this.isReachTargetPosition = false;
        decideTargetPotision();
        StartCoroutine(Shot());
    }

    void Update()
    {
        decideTargetPotision();
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, SPEED);

        if (transform.position == targetPosition)
        {
            isReachTargetPosition = true;
        }

        if (enemyLife.hp <= 20 && enemyLife.hp > 0)
        {
            SPEED = 0.2f;
        }

        else if (enemyLife.hp <= 50 && enemyLife.hp > 20)
        {
            SPEED = 0.1f;
        }

        else if (enemyLife.hp > 50)
        {
            SPEED = 0.05f;
        }

        else if (enemyLife.hp == 0)
        {
            StopCoroutine(Shot());
            SPEED = 0;
        }
    }

    // 目的地
    private void decideTargetPotision()
    {
        if (!isReachTargetPosition)
        {
            return;
        }

        targetPosition = new Vector3(Random.Range(X_MIN_MOVE_RANGE, X_MAX_MOVE_RANGE), Random.Range(Y_MIN_MOVE_RANGE, Y_MAX_MOVE_RANGE), 0);
        isReachTargetPosition = false;
    }

    void ArroundShot()
    {
        //var burret = _pool.GetBurret();
        //burret.transform.localPosition = transform.position;

        float shotSpeed = 3.0f;
        for (int i = 0; i < 12; i++)
        {
            Vector2 vec = player.transform.position - transform.position;
            vec.Normalize();
            // 24分割
            vec = Quaternion.Euler(0, 0, (360 / 12) * i) * vec;
            vec *= shotSpeed;
            //var t = Instantiate(EnemyBullet1, transform.position, EnemyBullet1.transform.rotation);
            var t = _pool.GetBurret();
            t.transform.localPosition = transform.position;

            t.GetComponent<Rigidbody2D>().velocity = vec;
        }
    }

    void NullShot()
    {
        //var burret = _pool.GetBurret();
        //burret.transform.localPosition = transform.position;

        float shotSpeed = 3.0f;
        for (int i = 0; i < 12; i++)
        {
            Vector2 vec = player.transform.position - transform.position;
            vec.Normalize();
            // 24分割
            vec = Quaternion.Euler(0, 0, (360 / 12) * i) * vec;
            vec *= shotSpeed;
            //var t = Instantiate(EnemyBullet1, transform.position, EnemyBullet1.transform.rotation);
            var t = SecondPool.GetBurret();
            t.transform.localPosition = transform.position;

            t.GetComponent<Rigidbody2D>().velocity = vec;
        }
    }

    IEnumerator Shot()
    {
        while (true)
        {
            if (enemyLife.hp <= 30 && enemyLife.hp > 0)
            {
                yield return new WaitForSeconds(1.5f);
                NullShot();
            }
            else if (enemyLife.hp <= 50 && enemyLife.hp > 30)
            {
                yield return new WaitForSeconds(3f);
                    ArroundShot();
            }
            else if (enemyLife.hp > 50)
            {
                yield return new WaitForSeconds(10f);
                ArroundShot();
            }
            else if (enemyLife.hp == 0)
            {
                yield break;
            }
        }
    }
}