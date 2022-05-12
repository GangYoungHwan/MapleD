using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    [SerializeField] int ShopNumber = 0;
    //private int MoneyType= 0;//�޼� = 1 ���̾� = 2 �Ǹ��������� = 0;
    //private int Producttype;//��ǰ Ÿ�� ��ų = 0 ������ = 1 �ƹ�Ÿ = 2
    //private int JobID = 0;//���� ���� = 1 ������ = 2 ���� = 3 �ü� = 4 �ʺ��� = 0
    //private string Name = null;//��ǰ �̸�
    //private string ItemPath = null;//�����۾�����
    //private int ItemCode = 0;//�������ڵ�
    //private int Price = 0;//����
    //private int SkillExp = 0;//��ų�߰�����ġ
    //private int SkillExpMax = 0;//��ų����ġMAX
    [SerializeField] private Image IconImage = null;
    [SerializeField] private TextMeshProUGUI NameText = null;
    [SerializeField] private TextMeshProUGUI SkillExpText = null;
    [SerializeField] private TextMeshProUGUI PriceText = null;
    [SerializeField] private Slider SkillExpSlider = null;
    [SerializeField] private TextMeshProUGUI SkillExpSliderText = null;
    [SerializeField] private GameObject _possession = null;
    private int ExpMax;
    private int LvMax;
    private int SkillLv;
    public int SkillExp;
    private void OnEnable()
    {
        string path = "Sprite/Icon/" + ShopNumber;
        IconImage.sprite = Resources.Load<Sprite>(path);
        ShopText(int.Parse(GoogleSheetManager.Instance.MyItems[ShopNumber].Producttype));
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShopText(int.Parse(GoogleSheetManager.Instance.MyItems[ShopNumber].Producttype));
        ButtonDisable();
    }


    void ShopText(int Producttype)
    {
        if(Producttype == 0)
        {
            ExpMax = int.Parse(GoogleSheetManager.Instance.MyItems[ShopNumber].SkillExpMax);
            LvMax = int.Parse(GoogleSheetManager.Instance.MyItems[ShopNumber].SkillLvMax);
            SkillLv = DataManager.Instance.playerData.Skill_Lv[ShopNumber];
            SkillExp = DataManager.Instance.playerData.Skill_exp[ShopNumber];
            SkillExpText.text = "x" + GoogleSheetManager.Instance.MyItems[ShopNumber].SkillExp;
            SkillExpSlider.value = SkillExp;
            SkillExpSlider.maxValue = (ExpMax / LvMax) * SkillLv;
            if (SkillLv == LvMax)
            {
                SkillExpSlider.maxValue = 1;
                SkillExpSlider.value = 1;
                SkillExpSliderText.text = "Max";
            }
            else
            {
                SkillExpSlider.value = SkillExp;
                SkillExpSlider.maxValue = (ExpMax / LvMax) * SkillLv;
                SkillExpSliderText.text = SkillExp + "/" + SkillExpSlider.maxValue;
            }
        }
        else
        {
            ExpMax = 0;
            LvMax = 0;
            SkillExp = 0;
            SkillLv = 0;
            SkillExpText = null;
            SkillExpSlider = null;
            SkillExpSliderText = null;
        }



        NameText.text = GoogleSheetManager.Instance.MyItems[ShopNumber].Name;
        PriceText.text = GoogleSheetManager.Instance.MyItems[ShopNumber].Price;
    }

    public void BuyButton()
    {
        DataManager.Instance.SelectNumber = ShopNumber;
    }

    private void ButtonDisable()
    {
        int data = int.Parse(GoogleSheetManager.Instance.MyItems[ShopNumber].ItemCode);
        if (GoogleSheetManager.Instance.MyItems[ShopNumber].Producttype == "0")
        {
            if (DataManager.Instance.playerData.Skill_Lv[data] == int.Parse(SkillInfoManager.Instance.SkillList[data].SkillLvMax))
            {
                this.gameObject.GetComponent<Button>().interactable = false;
                _possession.SetActive(true);
            }
            else
            {
                if (DataManager.Instance.playerData.Meso < int.Parse(GoogleSheetManager.Instance.MyItems[ShopNumber].Price))
                {
                    this.gameObject.GetComponent<Button>().interactable = false;
                }
                else
                {
                    this.gameObject.GetComponent<Button>().interactable = true;
                }
            }
        }
        else if(GoogleSheetManager.Instance.MyItems[ShopNumber].Producttype == "1")
        {
            if (DataManager.Instance.playerData.Meso < int.Parse(GoogleSheetManager.Instance.MyItems[ShopNumber].Price))
            {
                this.gameObject.GetComponent<Button>().interactable = false;
            }
            else
            {
                this.gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            if(DataManager.Instance.playerData.AvataSlot[data])
            {
                this.gameObject.GetComponent<Button>().interactable = false;
                _possession.SetActive(true);
            }
            else
            {
                if (DataManager.Instance.playerData.Dia < int.Parse(GoogleSheetManager.Instance.MyItems[ShopNumber].Price))
                {
                    this.gameObject.GetComponent<Button>().interactable = false;
                }
                else
                {
                    this.gameObject.GetComponent<Button>().interactable = true;
                }
            }
        }
    }
}
