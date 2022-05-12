using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestInfoSlot : MonoBehaviour
{
    [SerializeField] private int SlotNumber = 0;
    [SerializeField] private GameObject SelectBack= null;
    [SerializeField] private TextMeshProUGUI QuestName= null;
    [SerializeField] private Button Complete = null;

    private int QuestLv;
    private int KillMax;
    private int _Meso;
    private int _Exp;
    void Start()
    {
        
    }

    void Update()
    {
        QuestLv = DataManager.Instance.playerData.QuestLv[SlotNumber];
        KillMax = int.Parse(QuestInfoManager.Instance.QuestList[SlotNumber].Kill) * QuestLv;
        _Meso = int.Parse(QuestInfoManager.Instance.QuestList[SlotNumber].Meso) * QuestLv;
        _Exp = int.Parse(QuestInfoManager.Instance.QuestList[SlotNumber].Exp) * QuestLv;

        QuestName.text = QuestInfoManager.Instance.QuestList[SlotNumber].Name;
        if (DataManager.Instance.QuestSlotNumber == SlotNumber)
        {
            SelectBack.SetActive(true);
            QuestName.color = new Color(206 / 255f, 1f, 0f);
        }
        else
        {
            SelectBack.SetActive(false);
            QuestName.color = Color.white;
        }

        if (KillMax <= DataManager.Instance.playerData.QuestKill[SlotNumber])
            Complete.interactable = true;
        else
            Complete.interactable = false;
    }

    public void QuestSelectButton()
    {
        DataManager.Instance.QuestSlotNumber = SlotNumber;
    }
}
