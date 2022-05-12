using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class JobArrow2 : MonoBehaviour
{
    public GameObject Warrior;
    public GameObject Wizard;
    public GameObject Archer;
    public GameObject Log;

    public GameObject Warrior_Anim;
    public GameObject Wizard_Anim;
    public GameObject Archer_Anim;
    public GameObject Log_Anim;

    public GameObject CharJob; 
    public GameObject CharName; 
    public GameObject Deny;

    public InputField InputNickName;
    private int Job;

    private void Start()
    {
        Job = 2;
        JobSetActive(Job);
    }

    public void RightArrow()
    {
        if (Job >= 4)
            Job = 1;
        else
            Job++;
        JobSetActive(Job);
    }

    public void LeftArrow()
    {
        if (Job <= 1)
            Job = 4;
        else
            Job--;
        JobSetActive(Job);
    }
    public void CharaterCreateYes()
    {
        if (Job == 2)//마법사 생성
        {
            CharJob.SetActive(false);
            CharName.SetActive(true);
        }
        else//다른직업 미구현
        {
            Deny.SetActive(true);
        }
    }

    public void CharaterCreateNo()
    {
        SceneManager.LoadScene("CreateScene");
    }
    public void CharaterCreateNickNameOK()
    {
        int slot = DataManager.Instance.slotData._Slot;
        string Name = InputNickName.text;
        Debug.Log("슬롯" + slot);
        Debug.Log("닉네임"+Name);
        DataManager.Instance.SavePlayerDataToJson(slot+1, Name, Job);
        SoundManager.Instance.PlaySFXSound("ScrollUp");
        SceneManager.LoadScene("CharacterSelectScene");
    }

    public void CharaterCreateNickNameNo()
    {
        CharName.SetActive(false);
        CharJob.SetActive(true);

    }
    public void DenyOK()
    {
        Deny.SetActive(false);
    }
    void JobSetActive(int count)
    {
        Warrior.SetActive(false);
        Wizard.SetActive(false);
        Archer.SetActive(false);
        Log.SetActive(false);

        Warrior_Anim.SetActive(false);
        Wizard_Anim.SetActive(false);
        Archer_Anim.SetActive(false);
        Log_Anim.SetActive(false);


        switch (count)
        {
            case 1:
                Warrior.SetActive(true);
                Warrior_Anim.SetActive(true);
                break;
            case 2:
                Wizard.SetActive(true);
                Wizard_Anim.SetActive(true);
                break;
            case 3:
                Archer.SetActive(true);
                Archer_Anim.SetActive(true);
                break;
            case 4:
                Log.SetActive(true);
                Log_Anim.SetActive(true);
                break;
        }
    }
}
