using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject[] Maps = null;
    public int Stage_1 = 5;
    public int Stage_2 = 6;
    private void Awake()
    {
        if (DataManager.Instance.SpotNumber <= Stage_1)
        {
            Maps[0].SetActive(true);
        }
        else if(DataManager.Instance.SpotNumber >= Stage_2)
        {
            Maps[1].SetActive(true);
        }
    }
}
