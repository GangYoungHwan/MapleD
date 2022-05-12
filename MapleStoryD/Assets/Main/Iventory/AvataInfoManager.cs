using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[System.Serializable]
public class Avatas
{
    public Avatas(string _AvataNumber, string _AvataName, string _addDmg, string _addCritical, string _addCriticalDmg)
    {
        AvataNumber = _AvataNumber;
        AvataName = _AvataName;
        addDmg = _addDmg;
        addCritical = _addCritical;
        addCriticalDmg = _addCriticalDmg;
    }
    public string AvataNumber;
    public string AvataName;
    public string addDmg;
    public string addCritical;
    public string addCriticalDmg;
}
public class AvataInfoManager : MonoBehaviour
{
    private static AvataInfoManager instance = null;
    public List<Avatas> AvataList;
    const string URL = "https://docs.google.com/spreadsheets/d/1A1vyAderkzd7UVOBZU2UnWc7cwLjPIl56P_1BvfBJJI/export?format=tsv&gid=1609464553&range=A2:E";

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
    public static AvataInfoManager Instance { get { if (null == instance) { return null; } return instance; } }

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] line = data.Split('\n');
        for (int i = 0; i < line.Length; ++i)
        {
            string[] row = line[i].Split('\t');
            AvataList.Add(new Avatas(row[0], row[1], row[2], row[3], row[4]));
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
            AvataList.Add(new Avatas(row[0], row[1], row[2], row[3], row[4]));
        }
    }
}
