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
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float attackRate = 0.5f;
    [SerializeField] private float attackRange = 2.0f;
    public int SkillID;
    private int attackDamage;
    private int skillLV = 1;
    private State state = State.SearchTarget;
    private Transform attackTarget = null;
    private MonsterSpawner monsterSpawner;
    private void Awake()
    {
        attackDamage = int.Parse(SkillInfoManager.Instance.SkillList[SkillID].Att)*DataManager.Instance.playerData.Skill_Lv[SkillID];
    }
    public void Setup(MonsterSpawner monsterSpawner)
    {
        this.monsterSpawner = monsterSpawner;
        ChangeState(State.SearchTarget);
    }
    public void ChangeState(State newState)
    {
        //이전상태 종료
        StopCoroutine(state.ToString());
        //상태 변경
        state = newState;
        //새로운 상태
        StartCoroutine(state.ToString());
    }
    private IEnumerator SearchTarget()
    {
        while(true)
        {
            float closestDostSqr = Mathf.Infinity;//몬스터와 거리 저장
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
            SpawnProjectile();
            yield return new WaitForSeconds(attackRate);

            
        }
    }

    private void SpawnProjectile()
    {
        if(effectPrefab !=null)
        {
            Instantiate(effectPrefab, spawnPoint.position, Quaternion.identity);
        }
        GameObject clone = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<Projectile>().Setup(attackTarget, attackDamage, skillLV);
    }
}
