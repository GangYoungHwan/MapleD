using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[System.Serializable]
public class Quests
{
    public Quests(string _Name, string _Kill, string _Meso, string _Exp, string _Level, string _Info, string _Info2)
    {
        Name = _Name;
        Kill = _Kill;
        Meso = _Meso;
        Exp = _Exp;
        Level = _Level;
        Info = _Info;
        Info2 = _Info2;
    }
    public string Name;
    public string Kill;
    public string Meso;
    public string Exp;
    public string Level;
    public string Info;
    public string Info2;
}
public class QuestInfoManager : MonoBehaviour
{
    private static QuestInfoManager instance = null;
    public List<Quests> QuestList;
    const string URL = "https://docs.google.com/spreadsheets/d/1A1vyAderkzd7UVOBZU2UnWc7cwLjPIl56P_1BvfBJJI/export?format=tsv&gid=521224758&range=A2:G";

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
    public static QuestInfoManager Instance { get { if (null == instance) { return null; } return instance; } }

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] line = data.Split('\n');
        for (int i = 0; i < line.Length; ++i)
        {
            string[] row = line[i].Split('\t');
            QuestList.Add(new Quests(row[0], row[1], row[2],row[3], row[4], row[5], row[6]));
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
            QuestList.Add(new Quests(row[0], row[1], row[2], row[3], row[4], row[5], row[6]));
        }
    }
}
