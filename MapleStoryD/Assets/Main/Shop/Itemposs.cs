using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemposs : MonoBehaviour
{
    [SerializeField] private GameObject[] _possession = null;
    void Update()
    {
        for (int i = 0; i < _possession.Length; ++i)
        {
            if (DataManager.Instance.playerData.ItemSlot[i])
                _possession[i].SetActive(true);
            else
                _possession[i].SetActive(false);
        }
    }
}
