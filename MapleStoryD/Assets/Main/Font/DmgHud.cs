using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgHud : MonoBehaviour
{
    public int Dmg = 0;
    public GameObject _DmgSkin = null;
    void Start()
    {
        _DmgSkin.GetComponent<DmgRect>()._Dmg = Dmg;
    }
}
