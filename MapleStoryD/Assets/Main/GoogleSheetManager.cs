using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Item
{
    public Item(string _ImageNumber, string _MoneyType, string _Producttype, string _JobID, string _Name, string _ItemCode, string _Price, string _SkillExp, string _SkillExpMax,string _SkillLvMax)
    { ImageNumber = _ImageNumber; MoneyType = _MoneyType; Producttype = _Producttype; JobID = _JobID; Name = _Name; ItemCode = _ItemCode; Price = _Price; SkillExp = _SkillExp; SkillExpMax = _SkillExpMax; SkillLvMax = _SkillLvMax; }
    public string ImageNumber;
    public string MoneyType;//메소 = 1 다이아 = 2 판매하지않음 = 0;
    public string Producttype;//상품 타입 스킬 = 0 아이템 = 1 아바타 = 2
    public string JobID;//직업 전사 = 1 마법사 = 2 도적 = 3 궁수 = 4 초보자 = 0
    public string Name;//상품 이름
    public string ItemCode;//아이템코드
    public string Price;//가격
    public string SkillExp;//스킬추가경험치
    public string SkillExpMax;//스킬경험치MAX
    public string SkillLvMax;//스킬경험치MAX
}

public class GoogleSheetManager : MonoBehaviour
{
    private static GoogleSheetManager instance = null;
    public List<Item> MyItems;
    const string URL = "https://docs.google.com/spreadsheets/d/1A1vyAderkzd7UVOBZU2UnWc7cwLjPIl56P_1BvfBJJI/export?format=tsv&range=A2:J";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static GoogleSheetManager Instance { get { if (null == instance) { return null; } return instance; } }

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] line = data.Split('\n');
        for(int i=0; i<line.Length; ++i)
        {
            string[] row = line[i].Split('\t');
            MyItems.Add(new Item(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9]));
        }
    }
    private void Update()
    {
        
    }

    public IEnumerator Load()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] line = data.Split('\n');
        for (int i = 0; i < line.Length; ++i)
        {
            string[] row = line[i].Split('\t');
            MyItems.Add(new Item(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9]));
        }
    }
}
