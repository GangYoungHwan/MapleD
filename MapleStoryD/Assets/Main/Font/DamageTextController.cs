using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageTextController : MonoBehaviour
{
    private static DamageTextController _instance = null;

    public static DamageTextController Instance
    {
        get
        {
            if (_instance == null)
            {

                _instance = GameObject.FindObjectOfType<DamageTextController>();

                if (_instance == null)
                {
                    Debug.LogError("There's no active DamageTextController Object");
                }
            }

            return _instance;
        }
    }

    public GameObject dmgTxt;
    public GameObject CridmgTxt;
    public void CreateDamageText(bool Cri,Vector3 hitPoint, int hitDamage, Canvas canvas)
    {
        if(Cri)
        {
            GameObject damageText = Instantiate(dmgTxt, hitPoint, Quaternion.identity, canvas.transform);
            damageText.GetComponent<DmgHud>().Dmg = hitDamage;
        }
        else
        {
            GameObject damageText = Instantiate(CridmgTxt, hitPoint, Quaternion.identity, canvas.transform);
            damageText.GetComponent<DmgHud>().Dmg = hitDamage;
        }
    }
}
