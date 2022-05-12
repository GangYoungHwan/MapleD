using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Skills
{
    public Skills(string _Number, string _SkillType, string _JobID, string _Name, 
        string _Att, string _Critical, string _addAtt, string _addCritical, string _addCriticalDmg
        , string _SkillExpMax, string _SkillLvMax,string _Info)
    {
        Number = _Number;
        SkillType = _SkillType;
        JobID = _JobID;
        Name = _Name;
        Att = _Att;
        Critical = _Critical;
        addAtt = _addAtt;
        addCritical = _addCritical;
        addCriticalDmg = _addCriticalDmg;
        SkillExpMax = _SkillExpMax; 
        SkillLvMax = _SkillLvMax;
        Info = _Info;
    }
    public string Number;
    public string SkillType;
    public string JobID;
    public string Name;
    public string Att;
    public string Critical;
    public string addAtt;
    public string addCritical;
    public string addCriticalDmg;
    public string SkillExpMax;//스킬경험치MAX
    public string SkillLvMax;//스킬경험치MAX
    public string Info;
}
public class SkillInfoManager : MonoBehaviour
{
    private static SkillInfoManager instance = null;
    public List<Skills> SkillList;
    const string URL = "https://docs.google.com/spreadsheets/d/1A1vyAderkzd7UVOBZU2UnWc7cwLjPIl56P_1BvfBJJI/export?format=tsv&gid=234789987&range=A2:L";

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
    public static SkillInfoManager Instance { get { if (null == instance) { return null; } return instance; } }

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] line = data.Split('\n');
        for (int i = 0; i < line.Length; ++i)
        {
            string[] row = line[i].Split('\t');
            SkillList.Add(new Skills(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8],row[9], row[10],row[11]));
        }
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
            SkillList.Add(new Skills(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11]));
        }
    }
}
