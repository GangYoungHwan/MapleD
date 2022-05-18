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

    private int Max = 9;
    public Slot slotData;
    public int SlotNumber;

    public int SelectNumber;

    public int SkillSlotNumber;
    public int SkillType;
    public bool SkillMenu;

    public int ItemSlotNumber;
    public int AvataSlotNumber;
    

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
        save = PlayerInitialization(Slot,true, Name, Job);
        Slot save_Slot = new Slot();
        save_Slot = SlotInitialization(Slot);

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
                save = PlayerInitialization(0,false, "", 0);
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

    public PlayerData PlayerInitialization(int Slot,bool bSlot,string Name,int Job)
    {
        PlayerData init = new PlayerData();
        init.SlotNumber = Slot;
        init.Slot = bSlot;
        init.Name = Name;
        init.Job = Job;
        init.Level = 1;
        init.Meso = 0;
        init.Dia = 0;
        init.Exp = 0;
        init.Avata = 0;
        init.Critical = 0;
        init.CriticalDmg = 0;
        init.Dmg = 0;
        init.AvataSlot = new bool[Max];
        init.ItemSlot = new bool[Max];
        init.Skill = new bool[Max];
        init.Skill_ID = new int[Max];
        init.Skill_exp = new int[Max];
        init.Skill_Lv = new int[Max];
        init.ItemID = new int[Max];
        init.ItemNumber = new int[Max];
        init.AvataID = new int[Max];
        init.SkillActiveSlot = new bool[5];
        init.SkillPassiveSlot = new bool[5];
        init.SkillActiveSlotID = new int[5];
        init.SkillPassiveSlotID = new int[5];

        init.NextMap = 0;
        init.MapStar = new int[MapInfoManager.Instance.MapList.Count];
        init.MapBestStage = new int[MapInfoManager.Instance.MapList.Count];
        for (int i = 0; i < MapInfoManager.Instance.MapList.Count; i++)
        {
            init.MapStar[i] = 0;
            init.MapBestStage[i] = 0;
        }

        init.QuestLv = new int[QuestInfoManager.Instance.QuestList.Count];
        init.QuestKill = new int[QuestInfoManager.Instance.QuestList.Count];
        for (int i = 0; i < QuestInfoManager.Instance.QuestList.Count; i++)
        {
            init.QuestLv[i] = 1;
            init.QuestKill[i] = 0;
        }
        for (int i = 0; i < 5; i++)
        {
            init.SkillActiveSlot[i] = false;
            init.SkillPassiveSlot[i] = false;
            init.SkillActiveSlotID[i] = -1;
            init.SkillPassiveSlotID[i] = -1;
        }
        for (int i = 0; i < Max; i++)
        {
            init.AvataSlot[i] = false;
            init.AvataID[i] = 0;
            init.Skill[i] = true;
            init.Skill_ID[i] = 0;
            init.Skill_exp[i] = 0;
            init.Skill_Lv[i] = 1;

            init.ItemSlot[i] = false;
            init.ItemID[i] = 0;
            init.ItemNumber[i] = 0;

        }
        init.AvataSlot[0] = true;
        return init;
    }
    public Slot SlotInitialization(int Slot)
    {
        Slot save_Slot = new Slot();
        save_Slot._Slot = Slot;

        return save_Slot;
    }
}
