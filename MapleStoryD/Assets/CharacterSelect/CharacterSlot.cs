using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSlot : MonoBehaviour
{
    public GameObject NoCaracter_1;
    public GameObject NoCaracter_2;
    public GameObject NoCaracter_3;
    public GameObject NoCaracter_4;

    public GameObject Wizard_1;
    public GameObject Wizard_2;
    public GameObject Wizard_3;
    public GameObject Wizard_4;

    public GameObject WizardWalk_1;
    public GameObject WizardWalk_2;
    public GameObject WizardWalk_3;
    public GameObject WizardWalk_4;

    public GameObject NickName_1;
    public GameObject NickName_2;
    public GameObject NickName_3;
    public GameObject NickName_4;

    public int SelectSlotNumber;


    void Start()
    {
        SelectSlotNumber = 0;

        Loadcharacters();
    }

    void Update()
    {

    }

    public void Select_1()
    {
        if (DataManager.Instance.playerData_1.Slot)
        {
            SoundManager.Instance.PlaySFXSound("CharSelect");
            SelectSlotNumber = 1;
            DataManager.Instance.SlotNumber = SelectSlotNumber;
            WizardSelectAnim();
            Wizard_1.SetActive(false);
            WizardWalk_1.SetActive(true);
        }
    }
    public void Select_2()
    {
        if (DataManager.Instance.playerData_2.Slot)
        {
            SoundManager.Instance.PlaySFXSound("CharSelect");
            SelectSlotNumber = 2;
            DataManager.Instance.SlotNumber = SelectSlotNumber;
            WizardSelectAnim();
            Wizard_2.SetActive(false);
            WizardWalk_2.SetActive(true);
        }
    }
    public void Select_3()
    {
        if (DataManager.Instance.playerData_3.Slot)
        {
            SoundManager.Instance.PlaySFXSound("CharSelect");
            SelectSlotNumber = 3;
            DataManager.Instance.SlotNumber = SelectSlotNumber;
            WizardSelectAnim();
            Wizard_3.SetActive(false);
            WizardWalk_3.SetActive(true);
        }
    }
    public void Select_4()
    {
        if (DataManager.Instance.playerData_4.Slot)
        {
            SoundManager.Instance.PlaySFXSound("CharSelect");
            SelectSlotNumber = 4;
            DataManager.Instance.SlotNumber = SelectSlotNumber;
            WizardSelectAnim();
            Wizard_4.SetActive(false);
            WizardWalk_4.SetActive(true);
        }
    }
    private void WizardSelectAnim()
    {
        WizardWalk_1.SetActive(false);
        WizardWalk_2.SetActive(false);
        WizardWalk_3.SetActive(false);
        WizardWalk_4.SetActive(false);
        if (DataManager.Instance.playerData_1.Slot)
            Wizard_1.SetActive(true);
        if (DataManager.Instance.playerData_2.Slot)
            Wizard_2.SetActive(true);
        if (DataManager.Instance.playerData_3.Slot)
            Wizard_3.SetActive(true);
        if (DataManager.Instance.playerData_4.Slot)
            Wizard_4.SetActive(true);
    }

    public void DeleteCharacter()
    {
        DataManager.Instance.DeletePlayerDataToJson(SelectSlotNumber);
        Loadcharacters();
    }

    private void Loadcharacters()
    {
        Wizard_1.SetActive(false);
        Wizard_2.SetActive(false);
        Wizard_3.SetActive(false);
        Wizard_4.SetActive(false);
        WizardWalk_1.SetActive(false);
        WizardWalk_2.SetActive(false);
        WizardWalk_3.SetActive(false);
        WizardWalk_4.SetActive(false);
        NickName_1.SetActive(false);
        NickName_2.SetActive(false);
        NickName_3.SetActive(false);
        NickName_4.SetActive(false);
        if (DataManager.Instance.playerData_1.Slot)
        {
            Debug.Log("playerData_1");
            NoCaracter_1.SetActive(false);
            if (DataManager.Instance.playerData_1.Job == 1)
            {
                //미구현
            }
            if (DataManager.Instance.playerData_1.Job == 2)
            {
                Wizard_1.SetActive(true);
            }
            if (DataManager.Instance.playerData_1.Job == 3)
            {
                //미구현
            }
            if (DataManager.Instance.playerData_1.Job == 4)
            {
                //미구현
            }
            NickName_1.SetActive(true);
        }
        else
            NoCaracter_1.SetActive(true);

        if (DataManager.Instance.playerData_2.Slot)
        {
            NoCaracter_2.SetActive(false);
            if (DataManager.Instance.playerData_2.Job == 1)
            {
                //미구현
            }
            if (DataManager.Instance.playerData_2.Job == 2)
            {
                Wizard_2.SetActive(true);
            }
            if (DataManager.Instance.playerData_2.Job == 3)
            {
                //미구현
            }
            if (DataManager.Instance.playerData_2.Job == 4)
            {
                //미구현
            }
            NickName_2.SetActive(true);
        }
        else
            NoCaracter_2.SetActive(true);

        if (DataManager.Instance.playerData_3.Slot)
        {
            NoCaracter_3.SetActive(false);
            if (DataManager.Instance.playerData_3.Job == 1)
            {
                //미구현
            }
            if (DataManager.Instance.playerData_3.Job == 2)
            {
                Wizard_3.SetActive(true);
            }
            if (DataManager.Instance.playerData_3.Job == 3)
            {
                //미구현
            }
            if (DataManager.Instance.playerData_3.Job == 4)
            {
                //미구현
            }
            NickName_3.SetActive(true);
        }
        else
            NoCaracter_3.SetActive(true);

        if (DataManager.Instance.playerData_4.Slot)
        {
            NoCaracter_4.SetActive(false);
            if (DataManager.Instance.playerData_4.Job == 1)
            {
                //미구현
            }
            if (DataManager.Instance.playerData_4.Job == 2)
            {
                Wizard_4.SetActive(true);
            }
            if (DataManager.Instance.playerData_4.Job == 3)
            {
                //미구현
            }
            if (DataManager.Instance.playerData_4.Job == 4)
            {
                //미구현
            }
            NickName_4.SetActive(true);
        }
        else
            NoCaracter_4.SetActive(true);
    }
}
