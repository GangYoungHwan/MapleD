using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapArrow : MonoBehaviour
{
    [SerializeField] private GameObject Left = null;
    [SerializeField] private GameObject Right = null;
    [SerializeField] private GameObject Map_0 = null;
    [SerializeField] private GameObject Map_1 = null;

    public void MapRight()
    {
        if (DataManager.Instance.playerData.NextMap >= 6)
        {
            Map_0.SetActive(false);
            Map_1.SetActive(true);
            Right.SetActive(false);
            Left.SetActive(true);
        }
    }

    public void MapLeft()
    {
        Map_0.SetActive(true);
        Map_1.SetActive(false);
        Right.SetActive(true);
        Left.SetActive(false);
    }
}
