using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    private static InGameManager _instance = null;
    public static InGameManager Instance
    {
        get
        {
            if (_instance == null)
            {

                _instance = GameObject.FindObjectOfType<InGameManager>();

                if (_instance == null)
                {
                    Debug.LogError("There's no active DamageTextController Object");
                }
            }

            return _instance;
        }
    }
    public int cnt = 0;
    public int _SkillPoint;
    public List<SkillManager> skillList = null;
    public GameObject[] skillPrfab = null;
    public Transform[] skillslotPos = null;
    [SerializeField] private MonsterSpawner monsterSpawner;
    private void Start()
    {
        skillList = new List<SkillManager>();
        for (int i=0; i< 9; i++)
        {
            SkillManager skill = new SkillManager();
            skill._slot = false;
            skill._skillNum = 0;
            skillList.Add(skill);
        }
    }
    public void OnDice()
    {
        if (cnt >= skillList.Count)
        {
            Debug.Log("버튼 비활성화");
            return;
        }

        int _random = Random.Range(0, skillList.Count);
        int _Skillnum = Random.Range(0, 5);

        if (skillList[_random]._slot)
        {
            Debug.Log("중복");
            OnDice();
            return;
        }
        else
        {
            Debug.Log("카운트");
            cnt++;
        }
        skillList[_random]._slot = true;
        skillList[_random]._skillNum = DataManager.Instance.playerData.SkillActiveSlotID[_Skillnum];
        /*
        GameObject clone = Instantiate(skillPrfab[skillList[_random]._skillNum], skillslotPos[_random].position, Quaternion.identity);
        clone.GetComponent<Skill1>().Setup(monsterSpawner);
        */
        GameObject clone = Instantiate(skillPrfab[3], skillslotPos[0].position, Quaternion.identity);
        clone.GetComponent<Skill>().Setup(monsterSpawner);
    }
}
