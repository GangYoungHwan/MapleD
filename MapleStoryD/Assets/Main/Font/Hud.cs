using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public GameObject Cri;
    public GameObject NoCri;
    public float _destoryTime = 1.5f;
    private float EffectDestoryTime = 0.1f;
    void Start()
    {
        Invoke("DestoryEvent", _destoryTime);
    }
    public void DmgCri(float[] dmg, GameObject hitEft, Transform Target)
    {
        StartCoroutine(Crititcal(dmg, hitEft, Target));
    }

    public void DmgNoCri(float[] dmg, GameObject hitEft, Transform Target)
    {
        StartCoroutine(NoCritical(dmg, hitEft, Target));
    }
    private void DestoryEvent()
    {
        Destroy(gameObject);
    }
    private IEnumerator Crititcal(float[] dmg, GameObject hitEft, Transform Target)
    {
        Vector3 pos = Target.transform.position;
        for (int i = 0; i < dmg.Length; i++)
        {
            GameObject clone = Instantiate(Cri, gameObject.transform);
            clone.GetComponent<DmgHud>().Dmg = (int)dmg[i];
            GameObject hitEffclone = Instantiate(hitEft, pos, Quaternion.identity);
            yield return new WaitForSeconds(EffectDestoryTime);
        }
    }

    private IEnumerator NoCritical(float[] dmg, GameObject hitEft, Transform Target)
    {
        Vector3 pos = Target.transform.position;
        for (int i = 0; i < dmg.Length; i++)
        {
            GameObject clone = Instantiate(NoCri, gameObject.transform);
            clone.GetComponent<DmgHud>().Dmg = (int)dmg[i];
            GameObject hitEffclone = Instantiate(hitEft, pos, Quaternion.identity);
            yield return new WaitForSeconds(EffectDestoryTime);
        }
    }
}
