using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject BearButton;

    public GameObject[] enemys;
    public GameObject enemyImage;

    bool BattleOn = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (BattleOn == true)
            {
                SoundManager.instance.PlayBGM("Battle");
                objects[0].SetActive(false);
                objects[1].SetActive(false);
                objects[2].SetActive(true);
                objects[3].SetActive(true);

                BearButton.SetActive(true);

                StartCoroutine(ApperBoss());

                BattleOn = false;
            }
        }
    }

    IEnumerator ApperBoss()
    {
        while (enemyImage.transform.position.y > 4.5f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            enemyImage.transform.position += new Vector3(0, -2 * Time.deltaTime, 0);
        }
        enemys[0].SetActive(true);
        enemys[1].SetActive(true);
        enemyImage.SetActive(false);
    }

}
