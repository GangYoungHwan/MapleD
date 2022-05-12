using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int addDmg = 0;
    public int Critical = 0;
    public int CriticalDmg = 30;
    void Start()
    {
        Stat();
    }

    public void Stat()
    {
        int _addDmg = 0;
        int _Critical = 0;
        int _CriticalDmg = 30;
        int _avataID = DataManager.Instance.playerData.Avata;
        _addDmg += int.Parse(AvataInfoManager.Instance.AvataList[_avataID].addDmg);
        _Critical += int.Parse(AvataInfoManager.Instance.AvataList[_avataID].addCritical);
        _CriticalDmg += int.Parse(AvataInfoManager.Instance.AvataList[_avataID].addCriticalDmg);
        for (int i = 0; i < DataManager.Instance.playerData.SkillPassiveSlot.Length; i++)
        {
            if (DataManager.Instance.playerData.SkillPassiveSlot[i])
            {
                int SkillID = DataManager.Instance.playerData.SkillPassiveSlotID[i];
                int SkillLv = DataManager.Instance.playerData.Skill_Lv[SkillID];
                _addDmg += int.Parse(SkillInfoManager.Instance.SkillList[SkillID].addAtt);
                _Critical += int.Parse(SkillInfoManager.Instance.SkillList[SkillID].Critical);
                _Critical += (int.Parse(SkillInfoManager.Instance.SkillList[SkillID].addCritical) * SkillLv);
                _CriticalDmg += (int.Parse(SkillInfoManager.Instance.SkillList[SkillID].addCriticalDmg) * SkillLv);
            }
        }
        DataManager.Instance.playerData.Dmg = _addDmg;
        DataManager.Instance.playerData.Critical = _Critical;
        DataManager.Instance.playerData.CriticalDmg = _CriticalDmg;
        addDmg = DataManager.Instance.playerData.Dmg;
        Critical = DataManager.Instance.playerData.Critical;
        CriticalDmg = DataManager.Instance.playerData.CriticalDmg;

        DataManager.Instance.SavePlayer(DataManager.Instance.SlotNumber);//ÀúÀå
    }
}
