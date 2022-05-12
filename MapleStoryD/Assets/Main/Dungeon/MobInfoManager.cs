using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[System.Serializable]
public class Mobs
{
    public Mobs(string _MobCode, string _MobName, string _MobLevel, string _MobHP, string _MobSpeed, string _MesoMax, string _MobExp)
    {
        MobCode = _MobCode;
        MobName = _MobName;
        MobLevel = _MobLevel;
        MobHP = _MobHP;
        MobSpeed = _MobSpeed;
        MesoMax = _MesoMax;
        MobExp = _MobExp;
    }
    public string MobCode;
    public string MobName;
    public string MobLevel;
    public string MobHP;
    public string MobSpeed;
    public string MesoMax;
    public string MobExp;
}
public class MobInfoManager : MonoBehaviour
{
    private static MobInfoManager instance = null;
    public List<Mobs> MobList;
    const string URL = "https://docs.google.com/spreadsheets/d/1A1vyAderkzd7UVOBZU2UnWc7cwLjPIl56P_1BvfBJJI/export?format=tsv&gid=1913465242&range=A2:G";

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
    public static MobInfoManager Instance { get { if (null == instance) { return null; } return instance; } }

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] line = data.Split('\n');
        for (int i = 0; i < line.Length; ++i)
        {
            string[] row = line[i].Split('\t');
            MobList.Add(new Mobs(row[0], row[1], row[2], row[3], row[4], row[5], row[6]));
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
            MobList.Add(new Mobs(row[0], row[1], row[2], row[3], row[4], row[5], row[6]));
        }
    }
}
