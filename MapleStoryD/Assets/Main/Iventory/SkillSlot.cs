using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillSlot : MonoBehaviour
{
    [SerializeField] private int SlotNumber = 0;
    [SerializeField] private TextMeshProUGUI Name = null;
    [SerializeField] private Image Icon = null;
    [SerializeField] private Slider SkillExp = null;
    [SerializeField] private TextMeshProUGUI SkillExpText = null;
    [SerializeField] private TextMeshProUGUI Level = null;
    [SerializeField] private Image Select = null;

    int ExpMax;
    int LvMax;
    int SkillLv;
    private void OnEnable()
    {
        SkillInfo();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SkillInfo();
        SelectSkill();
    }

    void SkillInfo()
    {
        string path = "Sprite/SkillIcon/" + SlotNumber;
        Name.text = SkillInfoManager.Instance.SkillList[SlotNumber].Name;
        Icon.sprite = Resources.Load<Sprite>(path);
        ExpMax = int.Parse(SkillInfoManager.Instance.SkillList[SlotNumber].SkillExpMax);
        LvMax = int.Parse(SkillInfoManager.Instance.SkillList[SlotNumber].SkillLvMax);
        SkillLv = DataManager.Instance.playerData.Skill_Lv[SlotNumber];
        if (SkillLv == LvMax)
        {
            SkillExp.maxValue = 1;
            SkillExp.value = 1;
            SkillExpText.text = "Max";
        }
        else
        {
            SkillExp.value = DataManager.Instance.playerData.Skill_exp[SlotNumber];
            SkillExp.maxValue = (ExpMax / LvMax) * SkillLv;
            SkillExpText.text = DataManager.Instance.playerData.Skill_exp[SlotNumber] + "/" + SkillExp.maxValue;
        }
        Level.text = DataManager.Instance.playerData.Skill_Lv[SlotNumber].ToString();
    }

    void SelectSkill()
    {
        bool _select = false;
        if(SkillInfoManager.Instance.SkillList[SlotNumber].SkillType == "0")
        {
            for(int i =0; i< DataManager.Instance.playerData.SkillActiveSlotID.Length; ++i)
            {
                if (DataManager.Instance.playerData.SkillActiveSlotID[i] == SlotNumber)
                    _select = true;
            }
        }
        else
        {
            for (int i = 0; i < DataManager.Instance.playerData.SkillPassiveSlotID.Length; ++i)
            {
                if (DataManager.Instance.playerData.SkillPassiveSlotID[i] == SlotNumber)
                    _select = true;
            }
        }
        if(_select)
            Select.gameObject.SetActive(true);
        else
            Select.gameObject.SetActive(false);
    }
}
