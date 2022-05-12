using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float MoveSpeed = 0.5f;
    Rigidbody2D rigid = null;
    SpriteRenderer Mob = null;
    public int nextMove = 0;
    Animator anim = null;
    public Transform dmgPos = null;
    private MonsterSpawner monsterSpawner;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Mob = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    public void Setup(MonsterSpawner monsterSpawner)
    {
        this.monsterSpawner = monsterSpawner;
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove*MoveSpeed, rigid.velocity.y);
        if (nextMove == 1)
        {
            Mob.flipX = true;
            anim.SetTrigger("isWalking");
        }
        else if (nextMove == -1)
        {
            Mob.flipX = false;
            anim.SetTrigger("isWalking");
        }
        else if (nextMove == 0)
        {
            anim.ResetTrigger("isWalking");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WayRight")
        {
            nextMove = -1;
        }
        else if (collision.gameObject.tag == "WayLeft")
        {
            nextMove = 1;
        }
    }

    public void OnDie()
    {
        monsterSpawner.DestroyMonster(this);
        nextMove = 0;
        anim.SetTrigger("isDie");
    }
    private void OnDestroyEvent()
    {
        Destroy(gameObject);
    }
}
