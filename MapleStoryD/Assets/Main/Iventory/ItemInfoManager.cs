using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Items
{
    public Items(string _ItemNumber, string _ItemName, string _ItemInfo)
    {
        ItemNumber = _ItemNumber;
        ItemName = _ItemName;
        ItemInfo = _ItemInfo;
    }
    public string ItemNumber;
    public string ItemName;
    public string ItemInfo;
}
public class ItemInfoManager : MonoBehaviour
{
    private static ItemInfoManager instance = null;
    public List<Items> ItemList;
    const string URL = "https://docs.google.com/spreadsheets/d/1A1vyAderkzd7UVOBZU2UnWc7cwLjPIl56P_1BvfBJJI/export?format=tsv&gid=1691342571&range=A2:C";

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
    public static ItemInfoManager Instance { get { if (null == instance) { return null; } return instance; } }

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] line = data.Split('\n');
        for (int i = 0; i < line.Length; ++i)
        {
            string[] row = line[i].Split('\t');
            ItemList.Add(new Items(row[0], row[1], row[2]));
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
            ItemList.Add(new Items(row[0], row[1], row[2]));
        }
    }
}
