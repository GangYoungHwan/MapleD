using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHud : MonoBehaviour
{
    Vector3 _Position;
    private void Start()
    {
        _Position = new Vector3(-0.825f, 3.463f);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            /*
            Debug.Log("»ý¼º");
            int dmg = Random.Range(1, 100000);
            int cri = Random.Range(0, 2);
            bool _cri;
            if (cri == 0)
                _cri = false;
            else
                _cri = true;
            DamageTextController.Instance.CreateDamageText(_cri,_Position, dmg);
        */
        }
    }
}
