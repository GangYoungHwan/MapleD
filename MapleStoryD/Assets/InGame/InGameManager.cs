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
    public int Skillcnt = 0;
    public int _SkillPoint;
    public List<SkillManager> skillList = null;
    public List<SkillManager> passiveList = null;
    public GameObject[] skillPrfab = null;
    public GameObject[] passivePrfab = null;
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
            skill._skillID = 0;
            skillList.Add(skill);
        }
        passiveList = new List<SkillManager>();
        for(int i=0; i< DataManager.Instance.playerData.SkillPassiveSlot.Length; i++)
        {
            SkillManager passive = new SkillManager();
            passive._slot = DataManager.Instance.playerData.SkillPassiveSlot[i];
            passive._skillID = DataManager.Instance.playerData.SkillPassiveSlotID[i];
            passiveList.Add(passive);
        }
        //�нú� �ֱ�
    }
    public void OnDice()
    {
        if (Skillcnt >= skillList.Count)
        {
            Debug.Log("��ư ��Ȱ��ȭ");
            return;
        }

        int _random = Random.Range(0, skillslotPos.Length);
        int _Skillnum = Random.Range(0, 5);

        if (skillList[_random]._slot)
        {
            Debug.Log("�ߺ�");
            OnDice();
            return;
        }
        else
        {
            Skillcnt++;
        }
        CereteSkill(_Skillnum, skillslotPos[_random].position,0, _random);
        //skillList[_random]._slot = true;
        //skillList[_random]._skillNum = int.Parse(skillPrfab[_Skillnum].name);
        //GameObject clone = Instantiate(skillPrfab[_Skillnum], skillslotPos[_random].position, Quaternion.identity);
        //GameObject clone = Instantiate(skillPrfab[0], skillslotPos[_random].position, Quaternion.identity);
        //clone.GetComponent<Skill>().Setup(monsterSpawner);
    }
    public void CereteSkill(int skillnum,Vector3 pos,int Level,int SlotNum)
    {
        skillList[SlotNum]._slot = true;
        skillList[SlotNum]._skillID = int.Parse(skillPrfab[skillnum].name);
        GameObject clone = Instantiate(skillPrfab[skillnum], pos, Quaternion.identity);
        clone.GetComponent<Skill>().Setup(monsterSpawner, Level);
        clone.GetComponent<Skill>().SlotNum = SlotNum;
        clone.GetComponent<Skill>().SkillNum = skillnum;
        clone.GetComponent<Skill>().LevelUp();
    }
}
