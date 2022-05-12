using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class JobArrow : MonoBehaviour
{
    public GameObject Adventurers;
    public GameObject Cygnus;
    public GameObject Aran;
    public GameObject Evan;

    public GameObject Confirn_Adventurers;
    public GameObject Confirn_Cygnus;
    public GameObject Confirn_Aran;
    public GameObject Confirn_Evan;

    public GameObject confirn;
    public GameObject Deny;
    private int Count;

    private void Start()
    {
        Count = 1;
        JobSetActive(Count);
    }

    public void RightArrow()
    {
        if (Count >= 4)
            Count = 1;
        else
            Count++;
        JobSetActive(Count);
    }

    public void LeftArrow()
    {
        if (Count <= 1)
            Count = 4;
        else
            Count--;
        JobSetActive(Count);
    }
    public void CharaterCreateYes()
    {
        if (Count == 1)//모험가 생성
        {
            SoundManager.Instance.PlaySFXSound("ScrollUp");
            SceneManager.LoadScene("Create2Scene");
        }
        else//다른직업 미구현
        {
            confirn.SetActive(false);
            Deny.SetActive(true);
        }
    }

    public void DenyOK()
    {
        Deny.SetActive(false);
    }
    void JobSetActive(int count)
    {
        Adventurers.SetActive(false);
        Cygnus.SetActive(false);
        Aran.SetActive(false);
        Evan.SetActive(false);

        Confirn_Adventurers.SetActive(false);
        Confirn_Cygnus.SetActive(false);
        Confirn_Aran.SetActive(false);
        Confirn_Evan.SetActive(false);


        switch (count)
        {
            case 1:
                Adventurers.SetActive(true);
                Confirn_Adventurers.SetActive(true);
                break;
            case 2:
                Cygnus.SetActive(true);
                Confirn_Cygnus.SetActive(true);
                break;
            case 3:
                Aran.SetActive(true);
                Confirn_Aran.SetActive(true);
                break;
            case 4:
                Evan.SetActive(true);
                Confirn_Evan.SetActive(true);
                break;
        }
    }
}
