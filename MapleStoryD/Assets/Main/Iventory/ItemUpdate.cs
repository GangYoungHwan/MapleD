using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpdate : MonoBehaviour
{
    [SerializeField] private GameObject[] _itemSlot = null;
    void Update()
    {
        for (int i = 0; i < _itemSlot.Length; i++)
        {
            if (DataManager.Instance.playerData.ItemNumber[i] <= 0)
            {
                _itemSlot[i].SetActive(false);
                DataManager.Instance.playerData.ItemSlot[i] = false;
            }
            else
            {
                _itemSlot[i].SetActive(true);
                DataManager.Instance.playerData.ItemSlot[i] = true;
            }
        }

    }
}
