using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Name = null;
    [SerializeField] private TextMeshProUGUI MasterLv = null;
    [SerializeField] private Image Icon = null;
    [SerializeField] private Slider SkillExpSlider = null;
    [SerializeField] private TextMeshProUGUI SkillExpSliderText = null;
    [SerializeField] private TextMeshProUGUI SkillLvText = null;
    [SerializeField] private TextMeshProUGUI SkillInfoText = null;
    [SerializeField] private TextMeshProUGUI Att = null;
    [SerializeField] private TextMeshProUGUI Target = null;
    private int SkillID = 0;
    int ExpMax;
    int LvMax;
    int SkillLv;
    int SkillExp;



    void Start()
    {
        
    }

    void Update()
    {
        if(!DataManager.Instance.SkillMenu)
        {
            if (DataManager.Instance.SkillType == 0)
                SkillID = DataManager.Instance.playerData.SkillActiveSlotID[DataManager.Instance.SkillSlotNumber];
            else
                SkillID = DataManager.Instance.playerData.SkillPassiveSlotID[DataManager.Instance.SkillSlotNumber];
        }
        else
            SkillID = DataManager.Instance.SkillSlotNumber;

        Name.text = SkillInfoManager.Instance.SkillList[SkillID].Name;
        MasterLv.text = "[마스터 레벨 : "+SkillInfoManager.Instance.SkillList[SkillID].SkillLvMax+" ]";
        string path = "Sprite/SkillIcon/" + SkillID;
        Icon.sprite = Resources.Load<Sprite>(path);
        //SkillExp
        ExpMax = int.Parse(SkillInfoManager.Instance.SkillList[SkillID].SkillExpMax);
        LvMax = int.Parse(SkillInfoManager.Instance.SkillList[SkillID].SkillLvMax);
        SkillLv = DataManager.Instance.playerData.Skill_Lv[SkillID];
        SkillExp = DataManager.Instance.playerData.Skill_exp[SkillID];
        if (SkillLv == LvMax)
        {
            SkillExpSlider.maxValue = 1;
            SkillExpSlider.value = 1;
            SkillExpSliderText.text = "Max";
        }
        else
        {
            SkillExpSlider.value = SkillExp;
            SkillExpSlider.maxValue = (ExpMax / LvMax) * SkillLv;
            SkillExpSliderText.text = SkillExp + "/" + SkillExpSlider.maxValue;
        }
        SkillLvText.text = "Lv."+SkillLv.ToString();
        SkillInfoText.text = SkillInfoManager.Instance.SkillList[SkillID].Info;
        if(SkillInfoManager.Instance.SkillList[SkillID].SkillType == "0")
        {
            Att.text = "데미지 :" + (int.Parse(SkillInfoManager.Instance.SkillList[SkillID].Att) * SkillLv).ToString();
            Target.color = new Color(70 / 255f, 255 / 255f, 0f);
            Target.text = "[액티브스킬]";
        }
        else if(SkillInfoManager.Instance.SkillList[SkillID].SkillType == "1")
        {
            string _att;
            string _addCritical;
            string _addCriticalDmg;
            if (int.Parse(SkillInfoManager.Instance.SkillList[SkillID].addAtt) > 0)
                _att = "추가데미지 " + SkillInfoManager.Instance.SkillList[SkillID].addAtt + "%증가\n";
            else
                _att = "";
            if (int.Parse(SkillInfoManager.Instance.SkillList[SkillID].addCritical) > 0)
                _addCritical = "크리티컬 " +
                ((int.Parse(SkillInfoManager.Instance.SkillList[SkillID].addCritical) * DataManager.Instance.playerData.Skill_Lv[SkillID]) + int.Parse(SkillInfoManager.Instance.SkillList[SkillID].Critical)) +
                "%확률 증가\n";
            else
                _addCritical = "";
            if (int.Parse(SkillInfoManager.Instance.SkillList[SkillID].addCriticalDmg) > 0)
                _addCriticalDmg = "크리티컬 데미지 " + (int.Parse(SkillInfoManager.Instance.SkillList[SkillID].addCriticalDmg)*DataManager.Instance.playerData.Skill_Lv[SkillID]).ToString() + "% 증가\n";
            else
                _addCriticalDmg = "";


            Att.text = _att + _addCritical + _addCriticalDmg;
            Target.color = new Color(255 / 255f, 0f, 0f);
            Target.text = "[패시브스킬]";
        }
    }

    
}
