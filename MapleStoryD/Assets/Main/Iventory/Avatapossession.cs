using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatapossession : MonoBehaviour
{
    [SerializeField]private GameObject[] _possession = null;
    void Update()
    {
        for(int i=0; i< _possession.Length; ++i)
        {
            if (DataManager.Instance.playerData.AvataSlot[i])
                _possession[i].SetActive(true);
            else
                _possession[i].SetActive(false);
        }
    }
}
