using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Dray : MonoBehaviour
{
    public enum eMode{ idle, move, attack}
    
    [Header("Inscribed")] 
    public float speed = 5;
    public float attackDuration = 0.25f;
    public float attackDelay = 0.5f;
    
    [Header("Dynamic")] 
    public int dirHeld = -1;
    public int facing = 1;
    public eMode mode = eMode.idle;

    public float timeAtkDone = 0;
    public float timeAtkNext = 0;

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
        if(mode == eMode.attack && Time.time >= timeAtkDone) mode = eMode.idle;

        if (mode == eMode.idle || mode == eMode.move)
        {
            dirHeld = -1;
            for (int i=0; i<keys.Length; i++)
            {
                if (Input.GetKey(keys[i])) dirHeld = i % 4;
            }

            if (dirHeld == -1)
            {
                mode = eMode.idle;
            }
            else
            {
                facing = dirHeld;
                mode = eMode.move;
            }

            if (Input.GetKeyDown(KeyCode.Z) && Time.time >= timeAtkNext)
            {
                mode = eMode.attack;
                timeAtkDone = Time.time + attackDuration;
                timeAtkNext = Time.time + attackDelay;
            }
        }

        Vector2 vel = Vector2.zero;
        switch(mode)
        {
            case eMode.attack:
                anim.Play("Dray_Attack_" + facing);
                anim.speed = 0;
                break;
            case eMode.move:
                vel = directions[dirHeld];
                anim.Play("Dray_Walk_" + facing);
                anim.speed = 1;
                break;
            case eMode.idle:
                anim.Play("Dray_Walk_"+ facing);
                anim.speed = 0;
                break;
        }
       rigid.velocity = vel * speed; 
    }
}
