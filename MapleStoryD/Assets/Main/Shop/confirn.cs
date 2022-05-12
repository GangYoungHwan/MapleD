using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confirn : MonoBehaviour
{
    public GameObject LevelUpAnim;
    public GameObject confimAcquired;
    public GameObject confimBuy;
    public void buyInfoSave()
    {
        LevelUpAnim.SetActive(false);
        int Shop = DataManager.Instance.SelectNumber;
        int Data = int.Parse(GoogleSheetManager.Instance.MyItems[Shop].ItemCode);
        if(GoogleSheetManager.Instance.MyItems[Shop].Producttype == "0")
        {
            if (DataManager.Instance.playerData.Meso < int.Parse(GoogleSheetManager.Instance.MyItems[Shop].Price))
            {
                //皋家何练 备概给窃UI备泅
                confimBuy.SetActive(false);
                return;
            }
            else
            {
                DataManager.Instance.playerData.Meso -= int.Parse(GoogleSheetManager.Instance.MyItems[Shop].Price);
                confimAcquired.SetActive(true);
                if (!DataManager.Instance.playerData.Skill[Data])
                    DataManager.Instance.playerData.Skill[Data] = true;
                DataManager.Instance.playerData.Skill_exp[Data] += int.Parse(GoogleSheetManager.Instance.MyItems[Shop].SkillExp);
                SkillUp(Shop, Data);
            }
        }
        else if(GoogleSheetManager.Instance.MyItems[Shop].Producttype == "1")
        {
            if (DataManager.Instance.playerData.Meso < int.Parse(GoogleSheetManager.Instance.MyItems[Shop].Price))
            {
                //皋家何练 备概给窃UI备泅
                confimBuy.SetActive(false);
                return;
            }
            else
            {
                DataManager.Instance.playerData.Meso -= int.Parse(GoogleSheetManager.Instance.MyItems[Shop].Price);
                confimAcquired.SetActive(true);
                DataManager.Instance.playerData.ItemSlot[Data] = true;
                DataManager.Instance.playerData.ItemID[Data] = Data;
                DataManager.Instance.playerData.ItemNumber[Data] += 1;
            }
        }
        else
        {
            if (DataManager.Instance.playerData.Dia < int.Parse(GoogleSheetManager.Instance.MyItems[Shop].Price))
            {
                //备概给窃UI备泅
                confimBuy.SetActive(false);
                return;
            }
            else
            {
                DataManager.Instance.playerData.Dia -= int.Parse(GoogleSheetManager.Instance.MyItems[Shop].Price);
                confimAcquired.SetActive(true);
                if (!DataManager.Instance.playerData.AvataSlot[Data])
                {
                    DataManager.Instance.playerData.AvataSlot[Data] = true;
                    DataManager.Instance.playerData.AvataID[Data] = Data;

                }
            }
        }

        DataManager.Instance.SavePlayer(DataManager.Instance.SlotNumber);
        //DataManager.Instance.LoadPlayerDataToJson();

    }

    void SkillUp(int _shop,int _data)
    {
        int Producttype = int.Parse(GoogleSheetManager.Instance.MyItems[_shop].Producttype);
        if (Producttype != 0)
            return;

        int ExpMax = int.Parse(GoogleSheetManager.Instance.MyItems[_shop].SkillExpMax);
        int LvMax = int.Parse(GoogleSheetManager.Instance.MyItems[_shop].SkillLvMax);
        int SkillExp = DataManager.Instance.playerData.Skill_exp[_data];
        int SkillLv = DataManager.Instance.playerData.Skill_Lv[_data];

        int _ExpMax = (ExpMax / LvMax) * SkillLv;
        if (SkillExp >= _ExpMax)
        {
            LevelUpAnim.SetActive(true);
            DataManager.Instance.playerData.Skill_exp[_data] = 0;
            DataManager.Instance.playerData.Skill_exp[_data] += (SkillExp - _ExpMax);
            DataManager.Instance.playerData.Skill_Lv[_data] += 1;
        }
        
    }
}
