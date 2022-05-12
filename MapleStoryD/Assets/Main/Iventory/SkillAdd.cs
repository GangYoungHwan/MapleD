using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillAdd : MonoBehaviour
{
    [SerializeField] private Image[] Icon = null;
    [SerializeField] private int SlotNumber = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SkillAddButton()
    {
        for(int i = 0; i< Icon.Length; i++)
        {
            if(DataManager.Instance.SkillType == 0)
            {
                if (!DataManager.Instance.playerData.SkillActiveSlot[i]&&SkillInfoManager.Instance.SkillList[SlotNumber].SkillType == "0")
                {
                    string path = "Sprite/SkillIcon/" + SlotNumber;
                    Icon[i].sprite = Resources.Load<Sprite>(path);
                    DataManager.Instance.playerData.SkillActiveSlot[i] = true;
                    DataManager.Instance.playerData.SkillActiveSlotID[i] = SlotNumber;
                    this.gameObject.SetActive(false);
                    break;
                }
            }
            else
            {
                if (!DataManager.Instance.playerData.SkillPassiveSlot[i])
                {
                    string path = "Sprite/SkillIcon/" + SlotNumber;
                    Icon[i].sprite = Resources.Load<Sprite>(path);
                    DataManager.Instance.playerData.SkillPassiveSlot[i] = true;
                    DataManager.Instance.playerData.SkillPassiveSlotID[i] = SlotNumber;
                    this.gameObject.SetActive(false);
                    break;
                }
            }

        }
    }
}
