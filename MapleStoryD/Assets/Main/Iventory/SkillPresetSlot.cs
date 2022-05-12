using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillPresetSlot : MonoBehaviour
{
    [SerializeField] private int SlotNumber = 0;
    [SerializeField] private Image Icon = null;
    [SerializeField] private GameObject Empty = null;
    [SerializeField] private GameObject confim = null;
    [SerializeField] private GameObject Lv = null;
    [SerializeField] private TextMeshProUGUI LvText = null;
    int SkillID;
    void Start()
    {

    }

    void Update()
    {
        if(DataManager.Instance.SkillType == 0)
        {
            if (!DataManager.Instance.playerData.SkillActiveSlot[SlotNumber])
            {
                Empty.SetActive(true);
                string path = "Sprite/SkillIcon/Empty";
                Icon.sprite = Resources.Load<Sprite>(path);
                Lv.SetActive(false);
                LvText.text = "";
            }
            else
            {
                SkillID = DataManager.Instance.playerData.SkillActiveSlotID[SlotNumber];
                Empty.SetActive(false);
                string path = "Sprite/SkillIcon/" + SkillID;
                Icon.sprite = Resources.Load<Sprite>(path);
                Lv.SetActive(true);
                LvText.text = "Lv."+DataManager.Instance.playerData.Skill_Lv[SkillID].ToString();
            }
        }
        else
        {
            if (!DataManager.Instance.playerData.SkillPassiveSlot[SlotNumber])
            {
                Empty.SetActive(true);
                string path = "Sprite/SkillIcon/Empty";
                Icon.sprite = Resources.Load<Sprite>(path);
                Lv.SetActive(false);
                LvText.text = "";
            }
            else
            {
                SkillID = DataManager.Instance.playerData.SkillPassiveSlotID[SlotNumber];
                Empty.SetActive(false);
                string path = "Sprite/SkillIcon/" + SkillID;
                Icon.sprite = Resources.Load<Sprite>(path);
                Lv.SetActive(true);
                LvText.text = "Lv." + DataManager.Instance.playerData.Skill_Lv[SkillID].ToString();
            }
        }

    }
    public void DeleteSlotButton()
    {
        DataManager.Instance.SkillMenu = false;
        if (DataManager.Instance.SkillType == 0)
        {
            if (DataManager.Instance.playerData.SkillActiveSlot[SlotNumber])
            {
                DataManager.Instance.SkillSlotNumber = SlotNumber;
                confim.SetActive(true);
            }
        }
        else
        {
            if (DataManager.Instance.playerData.SkillPassiveSlot[SlotNumber])
            {
                DataManager.Instance.SkillSlotNumber = SlotNumber;
                confim.SetActive(true);
            }
        }

    }
    public void Close()
    {
        confim.SetActive(false);
    }
    public void DeleteButton()
    {
        int num = DataManager.Instance.SkillSlotNumber;
        int Length = DataManager.Instance.playerData.SkillActiveSlot.Length;
        if(DataManager.Instance.SkillType == 0)
        {
            for (int i = num; i < Length; i++)
            {
                if (i != Length - 1)
                {
                    DataManager.Instance.playerData.SkillActiveSlot[i] = DataManager.Instance.playerData.SkillActiveSlot[i + 1];
                    DataManager.Instance.playerData.SkillActiveSlotID[i] = DataManager.Instance.playerData.SkillActiveSlotID[i + 1];
                }
                else
                {
                    DataManager.Instance.playerData.SkillActiveSlot[i] = false;
                    DataManager.Instance.playerData.SkillActiveSlotID[i] = -1;
                }
            }
        }
        else
        {
            for (int i = num; i < Length; i++)
            {
                if (i != Length - 1)
                {
                    DataManager.Instance.playerData.SkillPassiveSlot[i] = DataManager.Instance.playerData.SkillPassiveSlot[i + 1];
                    DataManager.Instance.playerData.SkillPassiveSlotID[i] = DataManager.Instance.playerData.SkillPassiveSlotID[i + 1];
                }
                else
                {
                    DataManager.Instance.playerData.SkillPassiveSlot[i] = false;
                    DataManager.Instance.playerData.SkillPassiveSlotID[i] = -1;
                }
            }
        }

        Close();
    }
}
