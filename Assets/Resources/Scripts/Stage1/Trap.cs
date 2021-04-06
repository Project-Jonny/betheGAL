using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    Rigidbody2D rigidBody2D;

    public enum Type
    {
        Apper,
        Up,
        Down,
        Left,
        Right,
        DownRight,
        SMD,
    }

    public Type type;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void Action()
    {
        switch (type)
        {
            case Type.Apper:
                Apper();
                break;

            case Type.Up:
                Up();
                break;

            case Type.Down:
                Down();
                break;

            case Type.Left:
                Left();
                break;

            case Type.Right:
                Right();
                break;

            case Type.DownRight:
                DownRight();
                break;

            case Type.SMD:
                SMD();
                break;
        }
    }

    void Stay()
    {

    }
    void Apper()
    {
        gameObject.SetActive(true);
    }

    void Up()
    {
        rigidBody2D.velocity = Vector2.up * 15f;
        Destroy(gameObject, 5f);
    }

    void Down()
    {
        rigidBody2D.velocity = Vector2.down * 15f;
        Destroy(gameObject, 5f);
    }

    void Left()
    {
        rigidBody2D.velocity = Vector2.left * 15f;
        Destroy(gameObject, 5f);
    }

    void Right()
    {
        rigidBody2D.velocity = Vector2.right * 15f;
        Destroy(gameObject, 5f);
    }

    void DownRight()
    {
        Vector2 temp = new Vector2(1, -1.5f);
        temp.Normalize();
        rigidBody2D.velocity = temp * 15f;
        Destroy(gameObject, 5f);
    }

    void SMD()
    {
        rigidBody2D.velocity = Vector2.down * 8f;
        Destroy(gameObject, 5f);
    }
}
