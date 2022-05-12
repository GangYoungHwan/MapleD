using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    [SerializeField] private int MonsterID = 0;
    private int maxHP;
    private int currentHP;
    private bool isDie = false;
    private Monster monster;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        maxHP = int.Parse(MobInfoManager.Instance.MobList[MonsterID].MobHP);
        currentHP = maxHP;
        monster = GetComponent<Monster>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage,GameObject hud,Vector3 Pos)
    {
        if (isDie == true) return;
        //데이터 매니저 크리티컬 확률 구현
        bool critical = false;
        GameObject dmgSkinclone = Instantiate(hud, Pos, Quaternion.identity);
        if(critical)
            dmgSkinclone.GetComponent<Hud>().DmgCri(damage);//데미지 * 크리티컬데미지 구현
        else
            dmgSkinclone.GetComponent<Hud>().DmgNoCri(damage);

        currentHP -= damage;

        if(currentHP <= 0)
        {
            isDie = true;
            monster.OnDie();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
