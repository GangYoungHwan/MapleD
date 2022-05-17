using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ClearInfo : MonoBehaviour
{
    [SerializeField] private Text StageText = null;
    [SerializeField] private Text MesoText = null;
    [SerializeField] private Text ExpText = null;
    [SerializeField] private Text ClearTimeMinute = null;
    [SerializeField] private Text ClearTimeSecond = null;

    public int Stage;
    public int Meso;
    public int Exp;
    public int MobKill;

    private void Start()
    {
        MobKill = MonsterSpawner.Instance.dieMonstercnt;
        Stage = DataManager.Instance.SpotNumber;
        Meso = MobKill * 2;
        Exp = MonsterSpawner.Instance.MonsterExp;
        StageText.text = Stage.ToString();
        MesoText.text = Meso.ToString();
        ExpText.text = Exp.ToString();
        ClearTimeSecond.text = string.Format("{0:D2}", (int)MonsterSpawner.Instance.second);
        ClearTimeMinute.text = string.Format("{0:D2}", MonsterSpawner.Instance.minute);
    }
    public void OKbutton()
    {
        DataManager.Instance.playerData.Exp += Exp;
        DataManager.Instance.playerData.Meso += Meso;
        if(DataManager.Instance.playerData.NextMap <=DataManager.Instance.SpotNumber)
        {
            DataManager.Instance.playerData.NextMap += 1;
        }
        int Maxkill = MonsterSpawner.Instance.mobcntMax * MonsterSpawner.Instance.WaveMax; 
        if (Maxkill <= MobKill)
        {
            DataManager.Instance.playerData.MapStar[DataManager.Instance.SpotNumber] = 3;
        }
        else if(Maxkill/1.2 <= MobKill)
        {
            DataManager.Instance.playerData.MapStar[DataManager.Instance.SpotNumber] = 2;
        }
        else
        {
            DataManager.Instance.playerData.MapStar[DataManager.Instance.SpotNumber] = 1;
        }
        SceneManager.LoadScene("MainScene");
    }
}
