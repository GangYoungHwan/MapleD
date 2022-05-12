using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class profile : MonoBehaviour
{
    public Text NickName;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Dia;
    public TextMeshProUGUI Meso;
    [SerializeField] private GameObject _Avata = null;
    void Start()
    {
        NickName.text = DataManager.Instance.playerData.Name;
        Level.text = DataManager.Instance.playerData.Level.ToString();
        Dia.text = DataManager.Instance.playerData.Dia.ToString();
        Meso.text = DataManager.Instance.playerData.Meso.ToString();
        _Avata.GetComponent<AvataAnim>().AvataID = DataManager.Instance.playerData.Avata;
    }

    void Update()
    {
        NickName.text = DataManager.Instance.playerData.Name;
        Level.text = DataManager.Instance.playerData.Level.ToString();
        Dia.text = DataManager.Instance.playerData.Dia.ToString();
        Meso.text = DataManager.Instance.playerData.Meso.ToString();
        _Avata.GetComponent<AvataAnim>().AvataID = DataManager.Instance.playerData.Avata;
    }
}
