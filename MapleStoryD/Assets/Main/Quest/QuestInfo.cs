using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestInfo : MonoBehaviour
{
    [SerializeField] private GameObject NPC = null;
    [SerializeField] private GameObject[] QuestList = null;
    [SerializeField] private Image Progress = null;
    [SerializeField] private Image Complete = null;
    [SerializeField] private TextMeshProUGUI Info1 = null;
    [SerializeField] private TextMeshProUGUI Info2 = null;
    [SerializeField] private TextMeshProUGUI Kill = null;
    [SerializeField] private TextMeshProUGUI Meso = null;
    [SerializeField] private TextMeshProUGUI Exp = null;
    [SerializeField] private Button CompleteButton = null;
    private int QuestLv;
    private int SlotNumber;
    private int KillMax;
    private int _Meso;
    private int _Exp;
    void Start()
    {
        
    }

    void Update()
    {
        SlotNumber = DataManager.Instance.QuestSlotNumber;

        QuestLv = DataManager.Instance.playerData.QuestLv[SlotNumber];
        _Meso = int.Parse(QuestInfoManager.Instance.QuestList[SlotNumber].Meso) * QuestLv;
        _Exp = int.Parse(QuestInfoManager.Instance.QuestList[SlotNumber].Exp) * QuestLv;
        KillMax = int.Parse(QuestInfoManager.Instance.QuestList[SlotNumber].Kill) * QuestLv;

        Info1.text = QuestInfoManager.Instance.QuestList[SlotNumber].Info;
        Info2.text = QuestInfoManager.Instance.QuestList[SlotNumber].Info2;
        Kill.text = DataManager.Instance.playerData.QuestKill[SlotNumber].ToString() + "/" + KillMax.ToString();
        Meso.text = _Meso.ToString();
        Exp.text = _Exp.ToString();

        if (KillMax <= DataManager.Instance.playerData.QuestKill[SlotNumber])
        {
            CompleteButton.interactable = true;
        }
        else
        {
            CompleteButton.interactable = false;
        }

        if (DataManager.Instance.QuestTab)//진행중
        {
            for (int i = 0; i < QuestList.Length; i++)
            {
                if(int.Parse(QuestInfoManager.Instance.QuestList[i].Level)<DataManager.Instance.playerData.QuestLv[i])
                {
                    QuestList[i].SetActive(false);
                    Info1.gameObject.SetActive(false);
                    Info2.gameObject.SetActive(false);
                    Kill.gameObject.SetActive(false);
                    Meso.gameObject.SetActive(false);
                    Exp.gameObject.SetActive(false);
                    NPC.gameObject.SetActive(false);
                }
                else
                {
                    QuestList[i].SetActive(true);
                    Info1.gameObject.SetActive(true);
                    Info2.gameObject.SetActive(true);
                    Kill.gameObject.SetActive(true);
                    Meso.gameObject.SetActive(true);
                    Exp.gameObject.SetActive(true);
                    NPC.gameObject.SetActive(true);
                }
            }
            Progress.color = Color.white;
            Complete.color = new Color(135 / 255f, 135 / 255f, 135 / 255f);
        }
        else//완료
        {
            Progress.color = new Color(135 / 255f, 135 / 255f, 135 / 255f);
            Complete.color = Color.white;
            for(int i=0; i< QuestList.Length; i++)
            {
                QuestLv = DataManager.Instance.playerData.QuestLv[i];
                KillMax = int.Parse(QuestInfoManager.Instance.QuestList[i].Kill) * QuestLv;
                if (KillMax <= DataManager.Instance.playerData.QuestKill[i])
                {
                    QuestList[i].SetActive(true);
                }
                else
                {
                    QuestList[i].SetActive(false);
                }
            }
        }
    }

    public void TabProgress()
    {
        DataManager.Instance.QuestTab = true;
    }

    public void TabComplete()
    {
        DataManager.Instance.QuestTab = false;
    }

    public void QuestComplete()
    {
        int kill = int.Parse(QuestInfoManager.Instance.QuestList[SlotNumber].Kill) * DataManager.Instance.playerData.QuestLv[SlotNumber];
        DataManager.Instance.playerData.QuestKill[SlotNumber] -= kill;
        DataManager.Instance.playerData.QuestLv[SlotNumber] += 1;
    }

    public void QuestClose()
    {
        DataManager.Instance.SavePlayer(DataManager.Instance.SlotNumber);
        this.gameObject.SetActive(false);
    }
}
