using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[System.Serializable]
public class Level
{
    public Level(string _Level,string _ExpMax)
    {
        playerLevel = _Level;
        playerExpMax = _ExpMax;
    }
    public string playerLevel;
    public string playerExpMax;
}
public class LevelInfoManager : MonoBehaviour
{
    private static LevelInfoManager instance = null;
    public List<Level> LeveList;
    const string URL = "https://docs.google.com/spreadsheets/d/1A1vyAderkzd7UVOBZU2UnWc7cwLjPIl56P_1BvfBJJI/export?format=tsv&gid=1311731319&range=A2:B";

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
    public static LevelInfoManager Instance { get { if (null == instance) { return null; } return instance; } }

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] line = data.Split('\n');
        for (int i = 0; i < line.Length; ++i)
        {
            string[] row = line[i].Split('\t');
            LeveList.Add(new Level(row[0], row[1]));
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
            LeveList.Add(new Level(row[0], row[1]));
        }
    }
}
