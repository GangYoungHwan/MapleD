using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AvataSlot : MonoBehaviour
{
    [SerializeField] private int SlotNumber = 0;
    [SerializeField] private TextMeshProUGUI Name = null;
    [SerializeField] private Image Icon = null;
    [SerializeField] private Image Select = null;
    [SerializeField] private GameObject AvataSlotInfo = null;
    void Start()
    {
        
    }

    void Update()
    {
        int AvataID = DataManager.Instance.playerData.AvataID[SlotNumber];
        Name.text = AvataInfoManager.Instance.AvataList[AvataID].AvataName;
        string path = "Sprite/Avata/" + AvataID;
        Icon.sprite = Resources.Load<Sprite>(path);
        Icon.SetNativeSize();
        if (DataManager.Instance.playerData.Avata == AvataID)
            Select.gameObject.SetActive(true);
        else
            Select.gameObject.SetActive(false);
    }

    public void AvataInfoButton()
    {
        DataManager.Instance.AvataSlotNumber = DataManager.Instance.playerData.AvataID[SlotNumber];
        AvataSlotInfo.SetActive(true);
    }
}
