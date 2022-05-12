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
    public int Avata;//�ƹ�Ÿ
    //��ų
    public bool[] Skill;
    //public string[] Skill_name;
    public int[] Skill_ID;
    public int[] Skill_exp;
    public int[] Skill_Lv;
    //�ƹ�Ÿ
    public bool[] AvataSlot;
    public int[] AvataID;
    //������
    public bool[] ItemSlot;
    public int[] ItemID;
    public int[] ItemNumber;
    //��ų������
    public bool[] SkillActiveSlot;
    public int[] SkillActiveSlotID;
    public bool[] SkillPassiveSlot;
    public int[] SkillPassiveSlotID;
    //��
    public int NextMap;
    public int[] MapStar;
    public int[] MapBestStage;
    //����Ʈ
    public int[] QuestLv;
    public int[] QuestKill;
}
