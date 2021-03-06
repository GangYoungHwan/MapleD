using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    SearchTarget = 0,
    AttackToTarget
}
public class Skill : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject effectPrefab=null;
    //[SerializeField] private Transform spawnPoint;
    //private Transform spawnPoint;
    private Vector3 spawnPoint;
    [SerializeField] private float attackRate = 0.5f;
    [SerializeField] private float attackRange = 2.0f;
    public int SkillID = 0;
    public int SkillNum = 0;
    public int SlotNum = 0;
    public int AttackNum = 1;
    public int SkillType = 0;
    public int AttackMonsterCount = 1;
    private int attackDamage;
    public int powerLv = 1;
    public int skillLV = 0;
    private State state = State.SearchTarget;
    private Transform attackTarget = null;
    private MonsterSpawner monsterSpawner;
    [SerializeField] private GameObject[] starLv = null;
    [SerializeField] private GameObject StunEffect = null;
    private GameObject _stunEff = null;
    public float tempRange = 0;
    private void Awake()
    {
        attackDamage = int.Parse(SkillInfoManager.Instance.SkillList[SkillID].Att)*DataManager.Instance.playerData.Skill_Lv[SkillID];
        //spawnPoint = transform;
        spawnPoint = transform.position;
        tempRange = attackRange;
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(transform.position, attackRange);
    //}
    public void Setup(MonsterSpawner monsterSpawner,int Level,int SlotNum,int SkillNum)
    {
        this.skillLV = Level;
        this.monsterSpawner = monsterSpawner;
        this.SlotNum = SlotNum;
        this.SkillNum = SkillNum;
        ChangeState(State.SearchTarget);
    }
    public void LevelUp()
    {
        if (skillLV >= 6) return;
        starLv[skillLV].SetActive(false);
        skillLV += 1;
        starLv[skillLV].SetActive(true);
    }
    public void ChangeState(State newState)
    {
        //???????? ????
        StopCoroutine(state.ToString());
        //???? ????
        state = newState;
        //?????? ????
        StartCoroutine(state.ToString());
    }
    private IEnumerator SearchTarget()
    {
        while(true)
        {
            float closestDostSqr = Mathf.Infinity;//???????? ???? ????
            for(int i=0; i<monsterSpawner.MobList.Count; ++i)
            {
                float dis = Vector3.Distance(monsterSpawner.MobList[i].transform.position, transform.position);
                if(dis <=attackRange && dis <=closestDostSqr)
                {
                    closestDostSqr = dis;
                    attackTarget = monsterSpawner.MobList[i].transform;
                }
            }

            if(attackTarget !=null)
            {
                ChangeState(State.AttackToTarget);
            }
            yield return null;
        }
    }

    private IEnumerator AttackToTarget()
    {
        while(true)
        {
            if (attackTarget == null)
            {
                ChangeState(State.SearchTarget);
                break;
            }
            float dis = Vector3.Distance(attackTarget.position, transform.position);
            if(dis >attackRange)
            {
                attackTarget = null;
                ChangeState(State.SearchTarget);
                break;
            }
            if (AttackMonsterCount == 1)
                SpawnProjectile();
            else
                SpawnProjectile2(AttackMonsterCount);
            yield return new WaitForSeconds(attackRate);

            
        }
    }

    private void SpawnProjectile()
    {
        if(effectPrefab !=null)
        {
            GameObject effect = Instantiate(effectPrefab, spawnPoint, Quaternion.identity);
            effect.GetComponent<Hit>().SkillID = -1;
        }
        GameObject clone = Instantiate(projectilePrefab, spawnPoint, Quaternion.identity);
        clone.GetComponent<Projectile>().Setup(SkillType,attackTarget, attackDamage* powerLv, AttackNum, skillLV,SkillID);
    }

    private void SpawnProjectile2(int attackNum)
    {
        if (effectPrefab != null)
        {
            GameObject effect = Instantiate(effectPrefab, spawnPoint, Quaternion.identity);
            effect.GetComponent<Hit>().SkillID = -1;
        }
        bool monsterCount = false;
        int temp = 0;
        if (attackNum > monsterSpawner.MobList.Count)
        {
            attackNum = monsterSpawner.MobList.Count;
            monsterCount = true;
        }
        for (int i=0; i< attackNum; i++)
        {
            for(int j = 0; j< monsterSpawner.MobList.Count; j++)
            {
                if(!monsterCount)
                {
                    int rand;
                    while (true)
                    {
                        rand = Random.Range(0, monsterSpawner.MobList.Count);
                        if (temp != rand)
                        {
                            temp = rand;
                            break;
                        }
                    }
                    GameObject clones = Instantiate(projectilePrefab, spawnPoint, Quaternion.identity);
                    clones.GetComponent<Projectile>().Setup(SkillType, monsterSpawner.MobList[rand].transform, attackDamage* powerLv, AttackNum, skillLV, SkillID);
                }
                else
                {
                    GameObject clones = Instantiate(projectilePrefab, spawnPoint, Quaternion.identity);
                    clones.GetComponent<Projectile>().Setup(SkillType, monsterSpawner.MobList[j].transform, attackDamage* powerLv, AttackNum, skillLV, SkillID);
                }
                break;
            }
        }
    }

    public void SkillStop(float time)
    {
        StartCoroutine(skillstopAttack(time));
    }

    private IEnumerator skillstopAttack(float time)
    {
        _stunEff = Instantiate(StunEffect, gameObject.transform.position, Quaternion.identity);
        attackRange = 0f;
        yield return new WaitForSeconds(time);
        Destroy(_stunEff);
        attackRange = tempRange;
    }
}
