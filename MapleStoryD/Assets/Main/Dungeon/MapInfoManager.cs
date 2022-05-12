using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[System.Serializable]
public class Maps
{
    public Maps(string _MapCode, string _MapName, string _Mob_1, string _Mob_2, string _Mob_3, string _Mob_4, string _Mob_5, string _Mob_6, string _Boss)
    {
        MapCode = _MapCode;
        MapName = _MapName;
        Mob_1 = _Mob_1;
        Mob_2 = _Mob_2;
        Mob_3 = _Mob_3;
        Mob_4 = _Mob_4;
        Mob_5 = _Mob_5;
        Mob_6 = _Mob_6;
        Boss = _Boss;
    }
    public string MapCode;
    public string MapName;
    public string Mob_1;
    public string Mob_2;
    public string Mob_3;
    public string Mob_4;
    public string Mob_5;
    public string Mob_6;
    public string Boss;
}
public class MapInfoManager : MonoBehaviour
{
    private static MapInfoManager instance = null;
    public List<Maps> MapList;
    const string URL = "https://docs.google.com/spreadsheets/d/1A1vyAderkzd7UVOBZU2UnWc7cwLjPIl56P_1BvfBJJI/export?format=tsv&gid=1431236265&range=A2:I";

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
    public static MapInfoManager Instance { get { if (null == instance) { return null; } return instance; } }

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] line = data.Split('\n');
        for (int i = 0; i < line.Length; ++i)
        {
            string[] row = line[i].Split('\t');
            MapList.Add(new Maps(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8]));
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
            MapList.Add(new Maps(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8]));
        }
    }
}
