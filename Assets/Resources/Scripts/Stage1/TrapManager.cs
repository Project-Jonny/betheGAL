using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public Trap Trap;
    bool TrapAction = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (TrapAction)
            {
                Trap.Action();
                TrapAction = false;
            }
            else
            {
                return;
            }
        }
    }
}
