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
        PowerLevelText.text = PowerLevel.ToString();
        SkillpointText.text = SkillPoint.ToString();
    }

    public void SkillLevelUp()
    {
        if(InGameManager.Instance._SkillPoint > SkillPoint)
        {
            InGameManager.Instance._SkillPoint -= SkillPoint;
            PowerLevel++;
            SkillPoint = 60 * PowerLevel;
        }
        PowerLevelText.text = PowerLevel.ToString();
        SkillpointText.text = SkillPoint.ToString();

        GameObject[] _Skill = GameObject.FindGameObjectsWithTag("Skill");
        for (int i = 0; i < _Skill.Length; i++)
        {
            if (_Skill[i].GetComponent<Skill>().SkillID == SkillID)
            {
                _Skill[i].GetComponent<Skill>().powerLv = PowerLevel;
            }
        }
    }
}
