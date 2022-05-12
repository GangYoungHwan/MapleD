using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public GameObject Cri;
    public GameObject NoCri;
    public float _destoryTime = 1.5f;
    void Start()
    {
        Invoke("DestoryEvent", _destoryTime);
    }
    public void DmgCri(int dmg)
    {
        Cri.SetActive(true);
        Cri.GetComponent<DmgHud>().Dmg = dmg;
    }

    public void DmgNoCri(int dmg)
    {
        NoCri.SetActive(true);
        NoCri.GetComponent<DmgHud>().Dmg = dmg;
    }
    private void DestoryEvent()
    {
        Destroy(gameObject);
    }
}
