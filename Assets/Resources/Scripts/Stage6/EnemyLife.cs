using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public GameObject DeathEffect;
    public GameObject Goal;

    bool Damage;

    public Slider HPSlider;
    public int hp;
    int hpMax = 100;

    void Start()
    {
        hp = hpMax;
        HPSlider.maxValue = hpMax;
        HPSlider.value = hpMax;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Damage = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Flash()
    {
        int count = 0;
        while (count < 10)
        {
            // 消える
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.2f);
            yield return new WaitForSeconds(0.1f); // 0.1秒まて
            // つく
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f); // 0.1秒まて
            count++;
        }
        Damage = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && Damage == true)
        {
            Damage = false;
            hp -= 5;
            if (hp <= 0)
            {
                hp = 0;
                StartCoroutine(DeathAni());
            }
            HPSlider.value = hp;

            StartCoroutine(Flash());
        }
    }

    IEnumerator DeathAni()
    {
        int count = 0;
        while (count < 10)
        {
            float randomX = Random.Range(-1.3f, 1.3f);
            float randomY = Random.Range(-1.3f, 1.3f);
            Vector3 vector3 = transform.position + new Vector3(randomX, randomY, 0);

            Instantiate(DeathEffect, vector3, this.transform.rotation);
            yield return new WaitForSeconds(0.2f);
            count++;
        }
        Goal.SetActive(true);
        SoundManager.instance.PlayBGM("7");
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
