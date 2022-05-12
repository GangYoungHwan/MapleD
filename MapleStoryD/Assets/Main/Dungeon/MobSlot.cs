using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MobSlot : MonoBehaviour
{
    [SerializeField] private int SlotNumber = 0;
    [SerializeField] private GameObject MobInfoSlot = null;
    [SerializeField] private TextMeshProUGUI MobInfo = null;
    [SerializeField] private Image MobIcon = null;
    private void OnEnable()
    {
        int MobID = 0;
        switch (SlotNumber)
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
            MobInfoSlot.SetActive(false);
        else
            MobInfoSlot.SetActive(true);

        MobInfo.text = MobInfoManager.Instance.MobList[MobID].MobName + "\nLv. " + MobInfoManager.Instance.MobList[MobID].MobLevel;
        string path = "Sprite/Mob/" + MobID;
        MobIcon.sprite = Resources.Load<Sprite>(path);
    }

    void Update()
    {

    }
}
