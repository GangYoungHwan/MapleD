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
        SoundManager.Instance.PlayBGMSound();
        skillList = new List<SkillManager>();
        for (int i=0; i< skillslotPos.Length; i++)
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

        int _random = Random.Range(0, skillslotPos.Length);
        int _Skillnum = Random.Range(0, 5);

        if (skillList[_random]._slot)
        {
            Debug.Log("중복");
            OnDice();
            return;
        }
        else
        {
            cnt++;
        }
        CereteSkill(0, skillslotPos[_random].position,1, _random);
        //skillList[_random]._slot = true;
        //skillList[_random]._skillNum = int.Parse(skillPrfab[_Skillnum].name);
        //GameObject clone = Instantiate(skillPrfab[_Skillnum], skillslotPos[_random].position, Quaternion.identity);
        //GameObject clone = Instantiate(skillPrfab[0], skillslotPos[_random].position, Quaternion.identity);
        //clone.GetComponent<Skill>().Setup(monsterSpawner);
    }
    public void CereteSkill(int skillnum,Vector3 pos,int Level,int random)
    {
        skillList[random]._slot = true;
        skillList[random]._skillNum = int.Parse(skillPrfab[skillnum].name);
        GameObject clone = Instantiate(skillPrfab[skillnum], pos, Quaternion.identity);
        clone.GetComponent<Skill>().Setup(monsterSpawner, Level);
    }
}
