using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Dungeon : MonoBehaviour
{
    [SerializeField] private GameObject[] MobInfoSlot = null;
    [SerializeField] private TextMeshProUGUI MapName = null;
    [SerializeField] private GameObject[] MyStar = null;
    [SerializeField] private TextMeshProUGUI BestStage = null;
    private void OnEnable()
    {
        int MobID = 0;
        for(int i=0; i < MobInfoSlot.Length; i++)
        {
            switch (i+1)
            {
                case 1:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_1);
                    break;
                case 2:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_2);
                    break;
                case 3:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_3);
                    break;
                case 4:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_4);
                    break;
                case 5:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_5);
                    break;
                case 6:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_6);
                    break;
                case 7:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Boss);
                    break;
                default:
                    Debug.Log("¿¡·¯ ID = " + MobID);
                    break;
            }
            if (MobID == 0)
                MobInfoSlot[i].SetActive(false);
            else
                MobInfoSlot[i].SetActive(true);
        }

        MapName.text = MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].MapName;
        for(int i=0; i < MyStar.Length; i++)
        {
            if(i == DataManager.Instance.playerData.MapStar[DataManager.Instance.SpotNumber])
                MyStar[i].SetActive(true);
            else
                MyStar[i].SetActive(false);
        }

        if (DataManager.Instance.playerData.MapBestStage[DataManager.Instance.SpotNumber] > 0)
            BestStage.text = "STAGE " + DataManager.Instance.playerData.MapBestStage[DataManager.Instance.SpotNumber].ToString();
        else
            BestStage.text = "";
    }

    public void OnDungeon()
    {
        SceneManager.LoadScene("GameScene");
    }
}
