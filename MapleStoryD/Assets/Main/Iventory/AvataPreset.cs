using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AvataPreset : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Name = null;
    [SerializeField] private Image Avata = null;
    private int Number;
    void Start()
    {
        
    }

    void Update()
    {
        Number = DataManager.Instance.playerData.Avata;
        string path = "Sprite/Avata/" + Number;
        Avata.sprite = Resources.Load<Sprite>(path);
        Avata.SetNativeSize();
        Name.text = AvataInfoManager.Instance.AvataList[Number].AvataName;
    }
}
