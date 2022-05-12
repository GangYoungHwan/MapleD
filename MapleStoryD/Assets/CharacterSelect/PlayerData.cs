using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerData
{
    public int SlotNumber;

    public bool Slot;
    public string Name;
    public int Job;
    public int Level;
    public int Meso;
    public int Dia;
    public int Exp;
    public int Avata;//아바타
    //스킬
    public bool[] Skill;
    //public string[] Skill_name;
    public int[] Skill_ID;
    public int[] Skill_exp;
    public int[] Skill_Lv;
    //아바타
    public bool[] AvataSlot;
    public int[] AvataID;
    //아이템
    public bool[] ItemSlot;
    public int[] ItemID;
    public int[] ItemNumber;
    //스킬프리셋
    public bool[] SkillActiveSlot;
    public int[] SkillActiveSlotID;
    public bool[] SkillPassiveSlot;
    public int[] SkillPassiveSlotID;
    //맵
    public int NextMap;
    public int[] MapStar;
    public int[] MapBestStage;
    //퀘스트
    public int[] QuestLv;
    public int[] QuestKill;
}
