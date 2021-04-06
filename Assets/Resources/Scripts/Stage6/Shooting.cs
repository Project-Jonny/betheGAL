using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform ShootingPos;

    public void Shot()
    {
        SoundManager.instance.PlaySE(3);
        GameObject inst;
        inst = Instantiate(bullet, ShootingPos.position, ShootingPos.rotation);
        inst.GetComponent<Bullet>().pos.x = ShootingPos.parent.localScale.x;
    }
}
