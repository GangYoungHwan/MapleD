using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpotInfo : MonoBehaviour
{
    [SerializeField] private int SpotNumber = 0;
    [SerializeField] private TextMeshProUGUI SpotName = null;
    [SerializeField] private GameObject[] Star = null;
    [SerializeField] private GameObject confirn = null;
    void Start()
    {
        if(DataManager.Instance.playerData.NextMap < SpotNumber)
            this.GetComponent<Button>().interactable = false;
        else
            this.GetComponent<Button>().interactable = true;

        SpotName.text = MapInfoManager.Instance.MapList[SpotNumber].MapName;
        for(int i=0; i<Star.Length; i++)
        {
            if(DataManager.Instance.playerData.MapStar[SpotNumber]==i)
                Star[i].SetActive(true);
            else
                Star[i].SetActive(false);
        }
        if (DataManager.Instance.playerData.NextMap == SpotNumber)
            this.GetComponent<Animator>().enabled = true;
        else
            this.GetComponent<Animator>().enabled = false;
    }

    public void SpotButton()
    {
        DataManager.Instance.SpotNumber = SpotNumber;
        confirn.SetActive(true);
    }
}
