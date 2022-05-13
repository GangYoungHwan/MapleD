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

    public void TakeDamage(int skillType, bool cri,int AttackNum,int damage,GameObject hud,Vector3 Pos,GameObject hitEft,Transform Target)
    {
        float _Dmg = 0;
        if (isDie == true) return;
        float[] Damage = new float[AttackNum];
        for(int i=0; i< Damage.Length; i++)
        {
            float dmg = damage / Damage.Length;
            Damage[i] = Random.Range(dmg / 1.4f, dmg);
            _Dmg += Damage[i];
            
        }
        if(skillType == 0)
            monster.ChangeState(MonsterState.Normal);
        else if(skillType == 1)
            monster.ChangeState(MonsterState.Slow);
        else if (skillType == 2)
            monster.ChangeState(MonsterState.Stun);

        GameObject dmgSkinclone = Instantiate(hud, Pos, Quaternion.identity);
        
        if(cri)
            dmgSkinclone.GetComponent<Hud>().DmgCri(Damage, hitEft, Target);
        else
            dmgSkinclone.GetComponent<Hud>().DmgNoCri(Damage, hitEft, Target);
        currentHP -= (int)_Dmg;
        if(currentHP <= 0)
        {
            isDie = true;
            monster.OnDie();
        }
    }
}
