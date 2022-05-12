using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    [SerializeField] private int MonsterID = 0;
    private int maxHP;
    private int currentHP;
    public bool isDie = false;
    public bool isHit = false;
    private Monster monster;
    private SpriteRenderer spriteRenderer;



    private void Awake()
    {
        maxHP = int.Parse(MobInfoManager.Instance.MobList[MonsterID].MobHP);
        currentHP = maxHP;
        monster = GetComponent<Monster>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(bool cri,int damage,GameObject hud,Vector3 Pos)
    {
        if (isDie == true) return;
        //데이터 매니저 크리티컬 확률 구현
        GameObject dmgSkinclone = Instantiate(hud, Pos, Quaternion.identity);
        if(cri)
            dmgSkinclone.GetComponent<Hud>().DmgCri(damage);//데미지 * 크리티컬데미지 구현
        else
            dmgSkinclone.GetComponent<Hud>().DmgNoCri(damage);

        StopCoroutine("HitAnimtion");
        StartCoroutine("HitAnimtion");
        currentHP -= damage;
        if(currentHP <= 0)
        {
            isDie = true;
            monster.OnDie();
        }
    }
    
    private IEnumerator HitAnimtion()
    {
        Color color = spriteRenderer.color;
        color.r = 0.5f;
        color.g = 0.5f;
        color.b = 0.5f;
        spriteRenderer.color = color;
        yield return new WaitForSeconds(0.3f);
        color.r = 1f;
        color.g = 1f;
        color.b = 1f;
        spriteRenderer.color = color;
    }
}
