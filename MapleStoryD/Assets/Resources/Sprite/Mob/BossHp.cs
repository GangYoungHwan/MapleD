using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    public int BossID = 0;
    public int _BossHp = 0;
    public Slider BossHpSlider = null;
    [SerializeField] private Image BossIcon = null;
    public void SetUp(int BossID,int _BossHp)
    {
        this.BossID = BossID;
        this._BossHp = _BossHp;
        string path = "Sprite/Mob/" + BossID;
        BossIcon.sprite = Resources.Load<Sprite>(path);
        BossHpSlider.maxValue = _BossHp;
        BossHpSlider.value = _BossHp;
    }


    public void TakeBossAttack(float _bossHp)
    {
        BossHpSlider.value = _bossHp;
    }

}
