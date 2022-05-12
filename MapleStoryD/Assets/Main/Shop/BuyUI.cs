using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuyUI : MonoBehaviour
{
    [SerializeField] private Text Name = null;
    [SerializeField] private Image Icon = null;
    [SerializeField] private TextMeshProUGUI ExpText = null;
    [SerializeField] private Slider ExpSlider = null;
    [SerializeField] private Text ExpSliderExp = null;
    [SerializeField] private GameObject MesoIcon = null;
    [SerializeField] private GameObject DiaIcon = null;
    [SerializeField] private TextMeshProUGUI Price = null;
    int ItemNum;
    int Producttype;
    private int ExpMax;
    private int LvMax;
    private int SkillLv;
    private int SkillExp;

    void Start()
    {
        
    }


    void Update()
    {
        ItemNum = DataManager.Instance.SelectNumber;
        Producttype = int.Parse(GoogleSheetManager.Instance.MyItems[ItemNum].Producttype);
        string path = "Sprite/Icon/" + ItemNum;
        Icon.sprite = Resources.Load<Sprite>(path);
        Name.text = GoogleSheetManager.Instance.MyItems[ItemNum].Name;
        if (Producttype == 0)
        {
            Icon.transform.localPosition = new Vector3(0, 44, 0);
            Icon.rectTransform.sizeDelta = new Vector2(64, 64);
            ExpText.gameObject.SetActive(true);
            ExpSlider.gameObject.SetActive(true);
            ExpSliderExp.gameObject.SetActive(true);
            ExpMax = int.Parse(GoogleSheetManager.Instance.MyItems[ItemNum].SkillExpMax);
            LvMax = int.Parse(GoogleSheetManager.Instance.MyItems[ItemNum].SkillLvMax);
            SkillExp = DataManager.Instance.playerData.Skill_exp[ItemNum];
            SkillLv = DataManager.Instance.playerData.Skill_Lv[ItemNum];
            ExpText.text = "x" + GoogleSheetManager.Instance.MyItems[ItemNum].SkillExp;
            ExpSlider.value = DataManager.Instance.playerData.Skill_exp[ItemNum];
            ExpSlider.maxValue = (ExpMax / LvMax) * SkillLv;
            ExpSliderExp.text = SkillExp + "/" + ExpSlider.maxValue;
        }
        else if(Producttype == 1)
        {
            Icon.transform.localPosition = new Vector3(0, 22, 0);
            Icon.rectTransform.sizeDelta = new Vector2(64, 64);
            ExpMax = 0;
            LvMax = 0;
            SkillExp = 0;
            SkillLv = 0;
            ExpText.gameObject.SetActive(false);
            ExpSlider.gameObject.SetActive(false);
            ExpSliderExp.gameObject.SetActive(false);
        }
        else
        {
            Icon.transform.localPosition = new Vector3(0, 28, 0);
            Icon.rectTransform.sizeDelta = new Vector2(129, 106);
            ExpMax = 0;
            LvMax = 0;
            SkillExp = 0;
            SkillLv = 0;
            ExpText.gameObject.SetActive(false);
            ExpSlider.gameObject.SetActive(false);
            ExpSliderExp.gameObject.SetActive(false);
        }

        if (GoogleSheetManager.Instance.MyItems[ItemNum].MoneyType == "1")
        {
            DiaIcon.SetActive(false);
            MesoIcon.SetActive(true);
        }
        else
        {
            MesoIcon.SetActive(false);
            DiaIcon.SetActive(true);
        }
        Price.text = GoogleSheetManager.Instance.MyItems[ItemNum].Price;
    }
}
