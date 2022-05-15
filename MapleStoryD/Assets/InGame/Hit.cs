using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public int SkillID = 0;
    private void Start()
    {
        if (SkillID == -1) return;
        SoundManager.Instance.PlaySFXSound(SkillID+"_Hit");
    }
    public void SetUp(int skillID)
    {
        SkillID = skillID;
    }
    public void OnDestoryEff()
    {
        Destroy(this.gameObject);
    }
}
