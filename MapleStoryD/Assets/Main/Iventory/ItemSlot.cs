using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemSlot : MonoBehaviour
{
    [SerializeField] private int SlotNumber = 0;
    [SerializeField] private TextMeshProUGUI Name = null;
    [SerializeField] private Image Icon = null;
    [SerializeField] private TextMeshProUGUI Number = null;
    [SerializeField] private GameObject Info = null;
    private void OnEnable()
    {
        ItemInfo();
    }

    // Update is called once per frame
    void Update()
    {
        ItemInfo();
    }

    public void ItemInfo()
    {
        int ItemID = DataManager.Instance.playerData.ItemID[SlotNumber];
        string path = "Sprite/ItemIcon/" + ItemID;
        Icon.sprite = Resources.Load<Sprite>(path);
        Name.text = ItemInfoManager.Instance.ItemList[ItemID].ItemName;
        if (DataManager.Instance.playerData.ItemNumber[SlotNumber] > 999)
            Number.text = "999+";
        else
            Number.text = DataManager.Instance.playerData.ItemNumber[SlotNumber].ToString();
    }
    public void ItemInfoButton()
    {
        DataManager.Instance.ItemSlotNumber = SlotNumber;
        Info.SetActive(true);
    }
}
