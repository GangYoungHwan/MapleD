using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class powerUpSlot : MonoBehaviour
{
    [SerializeField] private int SkillID = 0;
    [SerializeField] private Text PowerLevelText = null;
    [SerializeField] private Text SkillpointText = null;
    private int SkillPoint = 60;
    private int PowerLevel = 1;
    void Start()
    {
        PowerLevelText.text = "LV." + PowerLevel.ToString();
        SkillpointText.text = SkillPoint.ToString();
    }
    private void Update()
    {
        GameObject[] _Skill = GameObject.FindGameObjectsWithTag("Skill");
        for (int i = 0; i < _Skill.Length; i++)
        {
            if (_Skill[i].GetComponent<Skill>().SkillID == SkillID)
            {
                _Skill[i].GetComponent<Skill>().powerLv = PowerLevel;
            }
        }
    }
    public void SkillLevelUp()
    {
        if(InGameManager.Instance._SkillPoint >= SkillPoint)
        {
            InGameManager.Instance.SetSkillPoint(-SkillPoint);
            PowerLevel++;
            SkillPoint *= PowerLevel;
        }
        PowerLevelText.text = "LV."+PowerLevel.ToString();
        SkillpointText.text = SkillPoint.ToString();
    }
}
