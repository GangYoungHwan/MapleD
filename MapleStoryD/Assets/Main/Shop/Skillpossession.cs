using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillpossession : MonoBehaviour
{
    [SerializeField] private GameObject[] _possession = null;
    void Update()
    {
        for (int i = 0; i < _possession.Length; ++i)
        {
            if (DataManager.Instance.playerData.Skill_Lv[i] == int.Parse(SkillInfoManager.Instance.SkillList[i].SkillLvMax))
                _possession[i].SetActive(true);
            else
                _possession[i].SetActive(false);
        }
    }
}
