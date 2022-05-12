using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AvataInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Name = null;
    [SerializeField] private Image Icon = null;
    [SerializeField] private TextMeshProUGUI Info = null;
    private int AvataID;

    void Update()
    {
        AvataID = DataManager.Instance.AvataSlotNumber;
        Name.text = AvataInfoManager.Instance.AvataList[AvataID].AvataName;
        string path = "Sprite/Avata/" + AvataID;
        Icon.sprite = Resources.Load<Sprite>(path);
        Icon.SetNativeSize();
        string _addDmg;
        string _addCritical;
        string _addCriticalDmg;
        if (int.Parse(AvataInfoManager.Instance.AvataList[AvataID].addDmg) > 0)
            _addDmg = "�߰������� " + AvataInfoManager.Instance.AvataList[AvataID].addDmg + "%����\n";
        else
            _addDmg = "";
        if (int.Parse(AvataInfoManager.Instance.AvataList[AvataID].addCritical) > 0)
            _addCritical = "ũ��Ƽ�� " +AvataInfoManager.Instance.AvataList[AvataID].addCritical +"%Ȯ�� ����\n";
        else
            _addCritical = "";
        if (int.Parse(AvataInfoManager.Instance.AvataList[AvataID].addCriticalDmg) > 0)
        {
            int addCriticalDmg = int.Parse(AvataInfoManager.Instance.AvataList[AvataID].addCriticalDmg);
            _addCriticalDmg = "ũ��Ƽ�� ������ " + addCriticalDmg.ToString() + "%����\n";
        }
        else
            _addCriticalDmg = "";

        Debug.Log(AvataInfoManager.Instance.AvataList[AvataID].addCriticalDmg);
        Info.text = _addDmg + _addCritical + _addCriticalDmg;
    }
    public void Close()
    {
        this.gameObject.SetActive(false);
    }
    public void AvataRegistrationButton()
    {
        DataManager.Instance.playerData.Avata = DataManager.Instance.playerData.AvataID[DataManager.Instance.AvataSlotNumber];
        DataManager.Instance.SavePlayer(DataManager.Instance.SlotNumber);
        Close();
    }
}
