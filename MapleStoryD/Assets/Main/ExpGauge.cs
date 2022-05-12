using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExpGauge : MonoBehaviour
{
    public Slider _expGauge;
    int Lvexp;
    void Start()
    {
        DataManager.Instance.SavePlayer(DataManager.Instance.SlotNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.Instance.playerData.Level <= 10)
            Lvexp = DataManager.Instance.playerData.Level * 10;
        else if (DataManager.Instance.playerData.Level > 10 &&DataManager.Instance.playerData.Level <= 20)
            Lvexp = DataManager.Instance.playerData.Level * 100;
        else if (DataManager.Instance.playerData.Level > 20 && DataManager.Instance.playerData.Level <= 30)
            Lvexp = DataManager.Instance.playerData.Level * 200;

        if (DataManager.Instance.playerData.Exp < Lvexp)
        {
            _expGauge.maxValue = Lvexp;
            _expGauge.minValue = 0;
            _expGauge.value = DataManager.Instance.playerData.Exp;
        }
        else
        {
            DataManager.Instance.playerData.Level++;
            DataManager.Instance.playerData.Exp = 0;
        }

        //DataManager.Instance.SavePlayer(DataManager.Instance.SlotNumber);
    }
}
