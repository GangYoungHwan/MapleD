using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
            }
            return _instance;
        }
    }
    public int Skillcnt = 0;
    public int _SkillPoint = 100;
    public int _DiceSP = 10;
    public int getSkillPoint = 10;
    public List<SkillManager> skillList = null;
    public List<SkillManager> passiveList = null;
    public GameObject[] skillPrfab = null;
    public GameObject[] passivePrfab = null;
    public Transform[] skillslotPos = null;
    public Button DiceButton = null;

    [SerializeField] private Text _SkillPointText = null;
    [SerializeField] private Text _DiceSPText = null;
    [SerializeField] private MonsterSpawner monsterSpawner = null;
    [SerializeField] private Transform _PassiveSkill = null;
    public Text _WaveText = null;
    public Text _WaveMaxText = null;
    public Text _MonsterLifeText = null;
    public Text _MonsterLifeMaxText = null;
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
        for(int i=0; i< passiveList.Count;i++)
        {
            if(passiveList[i]._slot)
            {
                Instantiate(passivePrfab[passiveList[i]._skillID], _PassiveSkill);
            }
        }
        _SkillPointText.text = _SkillPoint.ToString();
        _DiceSPText.text = _DiceSP.ToString();
    }
    private void Update()
    {
        if (Skillcnt >= skillList.Count || _SkillPoint < _DiceSP)
        {
            DiceButton.interactable = false;
        }
        else
        {
            DiceButton.interactable = true;
        }
    }
    public void OnDice()
    {
        int _random = Random.Range(0, skillslotPos.Length);
        int _Skillnum = Random.Range(0, 5);

        if (skillList[_random]._slot)
        {
            OnDice();
            return;
        }
        else
        {
            _SkillPoint -= _DiceSP;
            _DiceSP += 10;
            _DiceSPText.text = _DiceSP.ToString();
            _SkillPointText.text = _SkillPoint.ToString();
            Skillcnt++;
        }
        CereteSkill(_Skillnum, skillslotPos[_random].position,0, _random);
    }
    public void CereteSkill(int skillnum,Vector3 pos,int Level,int SlotNum)
    {
        skillList[SlotNum]._slot = true;
        skillList[SlotNum]._skillID = int.Parse(skillPrfab[skillnum].name);
        GameObject clone = Instantiate(skillPrfab[skillnum], pos, Quaternion.identity);
        clone.GetComponent<Skill>().Setup(monsterSpawner, Level, SlotNum, skillnum);
        clone.GetComponent<Skill>().LevelUp();
    }

    public void GetSkillPoint()
    {
        _SkillPoint += getSkillPoint;
        _SkillPointText.text = _SkillPoint.ToString();
    }
}
