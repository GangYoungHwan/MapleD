using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterAvataSlot : MonoBehaviour
{
    [SerializeField]private int SlotNum = 0;
    [SerializeField] private GameObject _NoCatacter = null;
    [SerializeField] private GameObject _NickName = null;
    [SerializeField] private GameObject _Avata = null;

    void Start()
    {
        switch (SlotNum)
        {
            case 1:
                PlayerAvataSlot(DataManager.Instance.playerData_1);
                break;
            case 2:
                PlayerAvataSlot(DataManager.Instance.playerData_2);
                break;
            case 3:
                PlayerAvataSlot(DataManager.Instance.playerData_3);
                break;
            case 4:
                PlayerAvataSlot(DataManager.Instance.playerData_4);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (SlotNum)
        {
            case 1:
                PlayerAvataSlot(DataManager.Instance.playerData_1);
                break;
            case 2:
                PlayerAvataSlot(DataManager.Instance.playerData_2);
                break;
            case 3:
                PlayerAvataSlot(DataManager.Instance.playerData_3);
                break;
            case 4:
                PlayerAvataSlot(DataManager.Instance.playerData_4);
                break;
        }

        if (SlotNum == DataManager.Instance.SlotNumber)
            _Avata.GetComponent<AvataAnim>().Avata_Walking = true;
        else
            _Avata.GetComponent<AvataAnim>().Avata_Walking = false;
    }

    private void PlayerAvataSlot(PlayerData data)
    {
        if (data.Slot)
        {
            _NoCatacter.SetActive(false);
            _Avata.SetActive(true);
            _Avata.GetComponent<AvataAnim>().AvataID = data.Avata;
        }
        else
        {
            _NoCatacter.SetActive(true);
            _Avata.SetActive(false);
            _NickName.SetActive(false);
        }
    }
    public void SelectButton()
    {
        DataManager.Instance.SlotNumber = SlotNum;
        SoundManager.Instance.PlaySFXSound("CharSelect");
    }

    public void DeleteCharacter()
    {
        DataManager.Instance.DeletePlayerDataToJson(DataManager.Instance.SlotNumber);
    }
}
