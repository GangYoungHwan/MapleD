using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvataAnim : MonoBehaviour
{
    public int AvataID = 0;
    public bool Avata_Walking = false;
    [SerializeField] GameObject[] _Avata = null;
    [SerializeField] GameObject[] _Avata_Walk = null;
    [SerializeField] GameObject _SelectEffect = null;

    void Update()
    {
        AvataAnimActive(AvataID, _Avata, _Avata_Walk);
    }
    private void AvataAnimActive(int AvataID, GameObject[] Avata,GameObject[] Walk)
    {
        for(int i=0; i< Avata.Length; i++)
        {
            if(i == AvataID)
            {
                if(Avata_Walking)
                {
                    _SelectEffect.SetActive(true);
                    Avata[i].SetActive(false);
                    Walk[i].SetActive(true);
                }
                else
                {
                    _SelectEffect.SetActive(false);
                    Walk[i].SetActive(false);
                    Avata[i].SetActive(true);
                }
            }
            else
            {
                Avata[i].SetActive(false);
                Walk[i].SetActive(false);
            }
        }
    }
}
