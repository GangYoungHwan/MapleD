using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    private static Player instance = null;
    [SerializeField] private Text NickNameText = null;
    [SerializeField] private TextMeshProUGUI LevelText= null;
    [SerializeField] private TextMeshProUGUI DiaText = null;
    [SerializeField] private TextMeshProUGUI MesoText = null;
    [SerializeField] private GameObject Avata = null;
    [SerializeField] private Slider ExpSlider = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static Player Instance { get { if (null == instance) { return null; } return instance; } }
    void Start()
    {
        ExpSlider.interactable = false;
        NickNameText.text = DataManager.Instance.playerData.Name;
        GetExp(0);
        GetDia(0);
        GetMeso(0);
        ChangeAvata(DataManager.Instance.playerData.Avata);
    }

    public void GetExp(int Exp)
    {
        int playerExp = DataManager.Instance.playerData.Exp;
        playerExp += Exp;
        while(true)
        {
            int playerLevel = DataManager.Instance.playerData.Level;
            int playerExpMax = int.Parse(LevelInfoManager.Instance.LeveList[playerLevel].playerExpMax);
            playerExpMax = int.Parse(LevelInfoManager.Instance.LeveList[playerLevel].playerExpMax);
            if (playerExp >= playerExpMax)
            {
                playerLevel += 1;
                playerExp -= playerExpMax;
                DataManager.Instance.playerData.Level = playerLevel;
                DataManager.Instance.playerData.Exp = playerExp;
            }
            else
                break;
        }
        int Level = DataManager.Instance.playerData.Level;
        LevelText.text = DataManager.Instance.playerData.Level.ToString();
        ExpSlider.maxValue = int.Parse(LevelInfoManager.Instance.LeveList[Level].playerExpMax);
        ExpSlider.value = playerExp;
        DataManager.Instance.SavePlayer(DataManager.Instance.SlotNumber);
    }

    public void GetDia(int dia)
    {
        DataManager.Instance.playerData.Dia += dia;
        DiaText.text = DataManager.Instance.playerData.Dia.ToString();
    }

    public void GetMeso(int meso)
    {
        DataManager.Instance.playerData.Meso += meso;
        MesoText.text = DataManager.Instance.playerData.Meso.ToString();
    }

    public void ChangeAvata(int AvataID)
    {
        DataManager.Instance.playerData.Avata = AvataID;
        Avata.GetComponent<AvataAnim>().AvataID = DataManager.Instance.playerData.Avata;
    }
}
