using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataManager : MonoBehaviour
{
  
    private static DataManager instance = null;
    public PlayerData playerData;
    public PlayerData playerData_1;
    public PlayerData playerData_2;
    public PlayerData playerData_3;
    public PlayerData playerData_4;

    public Slot slotData;
    public int SlotNumber;

    public int SelectNumber;

    public int SkillSlotNumber;
    public int SkillType;
    public bool SkillMenu;

    public int ItemSlotNumber;
    public int AvataSlotNumber;
    int Max = 9;

    public int SpotNumber;
    public int QuestSlotNumber;
    public bool QuestTab = true;


    private void Awake()
    {
        LoadPlayerDataToJson();
        if (instance ==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        //LoadPlayerDataToJson();
    }
    public static DataManager Instance { get { if (null == instance) { return null; } return instance; } }
    public void SavePlayer(int Slot)
    {
        PlayerData save = new PlayerData();
        save = playerData;
        string jsonData = JsonUtility.ToJson(save, true);
        string path = Path.Combine(Application.dataPath, "playerData_" + Slot + ".json");
        File.WriteAllText(path, jsonData);
        Debug.Log(Slot + "번슬롯 데이터저장 완료");
    }
    public void SavePlayerDataToJson(int Slot,string Name,int Job)
    {
        PlayerData save = new PlayerData();
        Slot save_Slot = new Slot();
        save_Slot._Slot = Slot;
        save.SlotNumber = Slot;
        save.Slot = true;
        save.Name = Name;
        save.Job = Job;
        save.Level = 1;
        save.Meso = 0;
        save.Dia = 0;
        save.Exp = 0;
        save.Avata = 0;
        save.AvataSlot = new bool[Max];
        save.ItemSlot = new bool[Max];
        save.Skill = new bool[Max];
        //save.Skill_name = new string[Max];
        save.Skill_ID = new int[Max];
        save.Skill_exp = new int[Max];
        save.Skill_Lv = new int[Max];
        save.ItemID = new int[Max];
        save.ItemNumber = new int[Max];
        save.AvataID = new int[Max];
        save.SkillActiveSlot = new bool[5];
        save.SkillPassiveSlot = new bool[5];
        save.SkillActiveSlotID = new int[5];
        save.SkillPassiveSlotID = new int[5];

        save.NextMap = 0;
        save.MapStar = new int[MapInfoManager.Instance.MapList.Count];
        save.MapBestStage = new int[MapInfoManager.Instance.MapList.Count];
        for (int i = 0; i < MapInfoManager.Instance.MapList.Count; i++)
        {
            save.MapStar[i] = 0;
            save.MapBestStage[i] = 0;
        }

        save.QuestLv = new int[QuestInfoManager.Instance.QuestList.Count];
        save.QuestKill = new int[QuestInfoManager.Instance.QuestList.Count];
        for(int i=0; i< QuestInfoManager.Instance.QuestList.Count; i++)
        {
            save.QuestLv[i] = 1;
            save.QuestKill[i] = 0;
        }
        for (int i=0; i<5; i++)
        {
            save.SkillActiveSlot[i] = false;
            save.SkillPassiveSlot[i] = false;
            save.SkillActiveSlotID[i] = -1;
            save.SkillPassiveSlotID[i] = -1;
        }
        for (int i = 0; i < Max; i++)
        {
            save.AvataSlot[i] = false;
            save.AvataID[i] = 0;
            //save.Skill_name[i] = "";
            save.Skill[i] = true;
            save.Skill_ID[i] = 0;
            save.Skill_exp[i] = 0;
            save.Skill_Lv[i] = 1;

            save.ItemSlot[i] = false;
            save.ItemID[i] = 0;
            save.ItemNumber[i] = 0;

        }
        save.AvataSlot[0] = true;
        string jsonData = JsonUtility.ToJson(save, true);
        string path = Path.Combine(Application.dataPath, "playerData_"+ Slot+".json");
        File.WriteAllText(path, jsonData);

        string jsonData2 = JsonUtility.ToJson(save_Slot, true);
        string path2 = Path.Combine(Application.dataPath, "Slot.json");
        File.WriteAllText(path2, jsonData2);
        Debug.Log("플레이어 "+ Slot + "  데이터 세이브완료");
        LoadPlayerDataToJson();
    }

    public void DeletePlayerDataToJson(int Slot)
    {
        if (Slot <= 0)
            return;

        for(int i=Slot;i<= 4;i++)
        {
            PlayerData save = new PlayerData();
            if (i == 1)
                save = playerData_2;
            else if (i == 2)
                save = playerData_3;
            else if (i == 3)
                save = playerData_4;
            else if (i == 4)
            {
                save.SlotNumber = 0;
                save.Slot = false;
                save.Name = "";
                save.Job = 0;
                save.Level = 1;
                save.Meso = 0;
                save.Dia = 0;
                save.Exp = 0;
                save.Avata = 0;
                save.AvataSlot = new bool[Max];
                save.ItemSlot = new bool[Max];
                save.Skill = new bool[Max];
                //save.Skill_name = new string[Max];
                save.Skill_ID = new int[Max];
                save.Skill_exp = new int[Max];
                save.Skill_Lv = new int[Max];
                save.ItemID = new int[Max];
                save.ItemNumber = new int[Max];
                save.AvataID = new int[Max];
                save.SkillActiveSlot = new bool[5];
                save.SkillPassiveSlot = new bool[5];
                save.SkillActiveSlotID = new int[5];
                save.SkillPassiveSlotID = new int[5];
                save.QuestLv = new int[QuestInfoManager.Instance.QuestList.Count];
                save.QuestKill = new int[QuestInfoManager.Instance.QuestList.Count];
                for (int a = 0; a < QuestInfoManager.Instance.QuestList.Count; a++)
                {
                    save.QuestLv[a] = 1;
                    save.QuestKill[a] = 0;
                }
                save.NextMap = 0;
                save.MapStar = new int[MapInfoManager.Instance.MapList.Count];
                save.MapBestStage = new int[MapInfoManager.Instance.MapList.Count];
                for (int l = 0; l < MapInfoManager.Instance.MapList.Count; l++)
                {
                    save.MapStar[l] = 0;
                    save.MapBestStage[l] = 0;
                }
                    
                for (int k = 0; k < 5; k++)
                {
                    save.SkillActiveSlot[k] = false;
                    save.SkillPassiveSlot[k] = false;
                    save.SkillActiveSlotID[k] = -1;
                    save.SkillPassiveSlotID[k] = -1;
                }
                for (int j = 0; j<Max; j++)
                {
                    save.AvataSlot[j] = false;
                    save.AvataID[j] = 0;
                    //save.Skill_name[j] = "";
                    save.Skill[j] = false;
                    save.Skill_ID[j] = 0;
                    save.Skill_exp[j] = 0;
                    save.Skill_Lv[j] = 1;

                    save.ItemSlot[j] = false;
                    save.ItemID[j] = 0;
                    save.ItemNumber[j] = 0;
                }
            }

            string jsonData = JsonUtility.ToJson(save, true);
            string path = Path.Combine(Application.dataPath, "playerData_" + i + ".json");
            File.WriteAllText(path, jsonData);
        }
        Slot save_Slot = slotData;
        save_Slot._Slot -= 1;
        string jsonData2 = JsonUtility.ToJson(save_Slot, true);
        string path2 = Path.Combine(Application.dataPath, "Slot.json");
        File.WriteAllText(path2, jsonData2);
        Debug.Log(Slot + "번 데이터 삭제완료");
        LoadPlayerDataToJson();
    }

    public void LoadPlayerDataToJson()
    {
        for(int i=1; i<=4; i++)
        {
            string path = Path.Combine(Application.dataPath, "playerData_"+i+".json");
            string jsonData = File.ReadAllText(path);
            if(i==1)
                playerData_1 = JsonUtility.FromJson<PlayerData>(jsonData);
            else if(i==2)
                playerData_2 = JsonUtility.FromJson<PlayerData>(jsonData);
            else if (i == 3)
                playerData_3 = JsonUtility.FromJson<PlayerData>(jsonData);
            else if (i == 4)
                playerData_4 = JsonUtility.FromJson<PlayerData>(jsonData);
        }
        
        string Slot_path = Path.Combine(Application.dataPath, "Slot.json");
        string Slot_jsonData = File.ReadAllText(Slot_path);
        slotData = JsonUtility.FromJson<Slot>(Slot_jsonData);

        Debug.Log("플레이어 모든데이터 로드완료");
    }
}
