using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public GameObject Cri;
    public GameObject NoCri;
    public float _destoryTime = 2.0f;
    private float EffectDestoryTime = 0.1f;
    void Start()
    {
        Invoke("DestoryEvent", _destoryTime);
    }
    public void DmgCri(float[] dmg, GameObject hitEft, Transform Target, int skillID)
    {
        StartCoroutine(Crititcal(dmg, hitEft, Target, skillID));
    }

    public void DmgNoCri(float[] dmg, GameObject hitEft, Transform Target, int skillID)
    {
        StartCoroutine(NoCritical(dmg, hitEft, Target, skillID));
    }
    private IEnumerator Crititcal(float[] dmg, GameObject hitEft, Transform Target,int skillID)
    {
        Vector3 pos = Target.GetComponent<Monster>().effectPos.position;
        for (int i = 0; i < dmg.Length; i++)
        {
            GameObject clone = Instantiate(Cri, gameObject.transform);
            clone.GetComponent<DmgHud>().Dmg = (int)dmg[i];
            GameObject hitEffclone = Instantiate(hitEft, pos, Quaternion.identity);
            hitEffclone.GetComponent<Hit>().SkillID = skillID;
            yield return new WaitForSeconds(EffectDestoryTime);
        }
    }

    private IEnumerator NoCritical(float[] dmg, GameObject hitEft, Transform Target,int skillID)
    {
        Vector3 pos = Target.GetComponent<Monster>().effectPos.position;
        for (int i = 0; i < dmg.Length; i++)
        {
            GameObject clone = Instantiate(NoCri, gameObject.transform);
            clone.GetComponent<DmgHud>().Dmg = (int)dmg[i];
            GameObject hitEffclone = Instantiate(hitEft, pos, Quaternion.identity);
            hitEffclone.GetComponent<Hit>().SkillID = skillID;
            yield return new WaitForSeconds(EffectDestoryTime);
        }
    }
    private void DestoryEvent()
    {
        Destroy(gameObject);
    }
}
