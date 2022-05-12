using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Name = null;
    [SerializeField] private Image Icon = null;
    [SerializeField] private TextMeshProUGUI Info = null;
    [SerializeField] private GameObject Test = null;
    int slotNum = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slotNum = DataManager.Instance.ItemSlotNumber;
        int itemID = DataManager.Instance.playerData.ItemID[slotNum];
        Name.text = ItemInfoManager.Instance.ItemList[itemID].ItemName;

        string path = "Sprite/ItemIcon/" + itemID;
        Icon.sprite = Resources.Load<Sprite>(path);

        Info.text = ItemInfoManager.Instance.ItemList[itemID].ItemInfo;
    }
    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void UseButton()
    {
        Test.SetActive(true);
        slotNum = DataManager.Instance.ItemSlotNumber;
        DataManager.Instance.playerData.ItemNumber[slotNum] -= 1;
        DataManager.Instance.SavePlayer(DataManager.Instance.SlotNumber);
        Close();
    }

    public void DelButton()
    {
        Test.SetActive(true);
        slotNum = DataManager.Instance.ItemSlotNumber;
        DataManager.Instance.playerData.ItemNumber[slotNum] -= 1;
        DataManager.Instance.SavePlayer(DataManager.Instance.SlotNumber);
        Close();
    }
}
