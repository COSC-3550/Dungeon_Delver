using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dray : MonoBehaviour
{
    [Header("Inscribed")] public float speed = 5;
    [Header("Dynamic")] public int dirHeld = -1;

    private Rigidbody2D rigid;
    private Animator anim;
    
    private Vector2[] directions = new Vector2[4]
    {
        Vector2.right, Vector2.up, Vector2.left, Vector2.down
    };

    private KeyCode[] keys = new KeyCode[]
    {
        KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow,
        KeyCode.D, KeyCode.W, KeyCode.A, KeyCode.S
    };

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        dirHeld = -1;
        /*if (Input.GetKey(KeyCode.RightArrow)) dirHeld = 0;
        if (Input.GetKey(KeyCode.UpArrow)) dirHeld = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) dirHeld = 2;
        if (Input.GetKey(KeyCode.DownArrow)) dirHeld = 3;*/
        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKey(keys[i])) dirHeld = i % 4;
        }
        
        Vector2 vel = Vector2.zero;

        /*switch (dirHeld)
        {
            case 0 : vel = Vector2.right; break;
            case 1: vel = Vector2.up; break;
            case 2: vel = Vector2.left; break;
            case 3: vel = Vector2.down; break;
        }*/
        if (dirHeld > -1) vel = directions[dirHeld];
        
        rigid.velocity = vel * speed;

        if (dirHeld == -1)
        {
            anim.speed = 0;
        }
        else
        {
            anim.Play("Dray_Walk_"+dirHeld);
            anim.speed = 1;
        }
    }
}
