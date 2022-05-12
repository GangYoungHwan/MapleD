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
    public void DmgCri(float[] dmg)
    {
        StartCoroutine(Crititcal(dmg));
    }

    public void DmgNoCri(float[] dmg)
    {
        StartCoroutine(NoCritical(dmg));
    }
    private void DestoryEvent()
    {
        Destroy(gameObject);
    }
    private IEnumerator Crititcal(float[] dmg)
    {
        for (int i = 0; i < dmg.Length; i++)
        {
            GameObject clone = Instantiate(Cri, gameObject.transform);
            clone.GetComponent<DmgHud>().Dmg = (int)dmg[i];
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator NoCritical(float[] dmg)
    {
        for (int i = 0; i < dmg.Length; i++)
        {
            GameObject clone = Instantiate(NoCri, gameObject.transform);
            clone.GetComponent<DmgHud>().Dmg = (int)dmg[i];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
