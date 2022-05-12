using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Acquired : MonoBehaviour
{
    [SerializeField] private Text Name = null;
    [SerializeField] private Image Icon = null;
    [SerializeField] private TextMeshProUGUI ExpText = null;
    [SerializeField] private Slider ExpSlider = null;
    [SerializeField] private Text ExpSliderExp = null;
    [SerializeField] private Text SkillLevel = null;
    int ItemNum;

    private int ExpMax;
    private int LvMax;
    private int SkillLv;
    private int SkillExp;
    int Producttype;
    private void OnEnable()
    {
        Debug.Log("È¹µæ");
    }
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
            Icon.transform.localPosition = new Vector3(0, 110, 0);
            Icon.rectTransform.sizeDelta = new Vector2(80, 80);
            ExpText.gameObject.SetActive(true);
            ExpSlider.gameObject.SetActive(true);
            ExpSliderExp.gameObject.SetActive(true);
            SkillLevel.gameObject.SetActive(true);
            ExpMax = int.Parse(GoogleSheetManager.Instance.MyItems[ItemNum].SkillExpMax);
            LvMax = int.Parse(GoogleSheetManager.Instance.MyItems[ItemNum].SkillLvMax);

            SkillExp = DataManager.Instance.playerData.Skill_exp[ItemNum];
            SkillLv = DataManager.Instance.playerData.Skill_Lv[ItemNum];

            SkillLevel.text = SkillLv.ToString();
            ExpText.text = "x" + GoogleSheetManager.Instance.MyItems[ItemNum].SkillExp;
            ExpSlider.value = DataManager.Instance.playerData.Skill_exp[ItemNum];
            ExpSlider.maxValue = (ExpMax / LvMax) * SkillLv;
            ExpSliderExp.text = SkillExp + "/" + ExpSlider.maxValue;
        }
        else if(Producttype == 1)
        {
            Icon.transform.localPosition = new Vector3(0, 110, 0);
            Icon.rectTransform.sizeDelta = new Vector2(100, 100);
            ExpMax = 0;
            LvMax = 0;
            SkillExp = 0;
            SkillLv = 0;
            ExpText.gameObject.SetActive(false);
            ExpSlider.gameObject.SetActive(false);
            ExpSliderExp.gameObject.SetActive(false);
            SkillLevel.gameObject.SetActive(false);
        }
        else
        {
            Icon.transform.localPosition = new Vector3(0, 110, 0);
            Icon.rectTransform.sizeDelta = new Vector2(165, 135);
            ExpMax = 0;
            LvMax = 0;
            SkillExp = 0;
            SkillLv = 0;
            ExpText.gameObject.SetActive(false);
            ExpSlider.gameObject.SetActive(false);
            ExpSliderExp.gameObject.SetActive(false);
            SkillLevel.gameObject.SetActive(false);
        }
        
    }
}
