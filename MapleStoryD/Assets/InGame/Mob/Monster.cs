using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MonsterState
{
    Normal = 0,
    Slow,
    Stun
}
public class Monster : MonoBehaviour
{
    public float MoveSpeed = 0.4f;
    Rigidbody2D rigid = null;
    SpriteRenderer Mob = null;
    public int nextMove = 0;
    Animator anim = null;
    public Transform dmgPos = null;
    private MonsterSpawner monsterSpawner;
    private MonsterState state = MonsterState.Normal;
    SpriteRenderer spriteRenderer = null;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Mob = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ChangeState(MonsterState newState)
    {
        //이전상태 종료
        StopCoroutine(state.ToString());
        //상태 변경
        state = newState;
        //새로운 상태
        StartCoroutine(state.ToString());
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

    public void monsterState(MonsterState state)
    {
        ChangeState(state);
    }
    private void OnDestroyEvent()
    {
        Destroy(gameObject);
    }

    private IEnumerator Normal()
    {
        MoveSpeed = 0.4f;
        Color color = spriteRenderer.color;
        color.r = 0.5f;
        color.g = 0.5f;
        color.b = 0.5f;
        spriteRenderer.color = color;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = Color.white;
    }
    private IEnumerator Slow()
    {
        MoveSpeed = 0.2f;
        Color col = new Color(100 / 255f, 180 / 255f, 1f);
        spriteRenderer.color = col;
        yield return new WaitForSeconds(2f);
        spriteRenderer.color = Color.white;
        ChangeState(MonsterState.Normal);
    }
    private IEnumerator Stun()
    {
        int tempMove = nextMove;
        nextMove = 0;
        yield return new WaitForSeconds(1f);
        nextMove = tempMove;
        ChangeState(MonsterState.Normal);
    }
}
