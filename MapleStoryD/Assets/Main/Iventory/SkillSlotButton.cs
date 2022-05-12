using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSlotButton : MonoBehaviour
{
    [SerializeField] private int SlotNumber = 0;
    [SerializeField] private GameObject confim = null;
    [SerializeField]
    private int selectNumber = 0;


    public void SlotButton()
    {
        DataManager.Instance.SkillSlotNumber = SlotNumber;
        DataManager.Instance.SkillMenu = true;
        confim.SetActive(true);
    }
    public void Close()
    {
        confim.SetActive(false);
    }

    public void SkillAddButton()
    {
        selectNumber = DataManager.Instance.SkillSlotNumber;
        int Length = DataManager.Instance.playerData.SkillActiveSlot.Length;
        Close();
        if (SkillInfoManager.Instance.SkillList[selectNumber].SkillType == "0")
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    if (DataManager.Instance.playerData.SkillActiveSlotID[j] == selectNumber)//중복검사
                        return;
                }
                if (!DataManager.Instance.playerData.SkillActiveSlot[i])
                {
                    DataManager.Instance.playerData.SkillActiveSlotID[i] = selectNumber;
                    DataManager.Instance.playerData.SkillActiveSlot[i] = true;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    if (DataManager.Instance.playerData.SkillPassiveSlotID[j] == selectNumber)//중복검사
                        return;
                }
                if (!DataManager.Instance.playerData.SkillPassiveSlot[i])
                {
                    DataManager.Instance.playerData.SkillPassiveSlotID[i] = selectNumber;
                    DataManager.Instance.playerData.SkillPassiveSlot[i] = true;
                    break;
                }
            }
        }
        DataManager.Instance.SavePlayer(DataManager.Instance.SlotNumber);
    }
}
