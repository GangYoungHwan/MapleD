using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject hitEff;
    [SerializeField] private GameObject dmgHud;
    private int attackNum;
    private int damage;
    private int skillLV;
    private Movement movement;
    private Transform target;


    public void Setup(Transform target,int damage,int attackNum, int skillLV)
    {
        movement = GetComponent<Movement>();
        this.target = target;
        this.damage = damage;
        this.attackNum = attackNum;
        this.skillLV = skillLV;
    }
    void Update()
    {
        if(target != null)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            movement.MoveTo(dir);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Mob"))
            return;
        if (collision.transform != target)
            return;
        float dmg = damage * skillLV;
        float addDmg = dmg * ((float)DataManager.Instance.playerData.Dmg / 100);
        dmg += addDmg;

        float Cri = DataManager.Instance.playerData.Critical;
        float CriDmg = dmg * ((float)DataManager.Instance.playerData.CriticalDmg / 100);
        int rand = Random.Range(1, 101);
        bool Critical = false;
        if (rand <= Cri)//크리티컬
        {
            Critical = true;
            dmg += CriDmg;
        }
        GameObject hitEffclone = Instantiate(hitEff, collision.transform.position, Quaternion.identity);
        Vector3 DmgskinPos = collision.GetComponent<Monster>().dmgPos.transform.position;
        collision.GetComponent<MonsterHP>().TakeDamage(Critical, attackNum, (int)dmg, dmgHud, DmgskinPos);
        Destroy(gameObject);
    }
}
