using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuButton : MonoBehaviour
{
    Vector3[] Target = new Vector3[4];
    [SerializeField] float m_speed = 0f;
    [SerializeField] GameObject WolrdMaps = null;
    [SerializeField] GameObject Ranking = null;
    private int TargetNum = 0;

    void Start()
    {
        DataManager.Instance.SavePlayer(DataManager.Instance.SlotNumber);
        Target[0] = new Vector3(0, 0, 0);
        Target[1] = new Vector3(640, 0, 0);
        Target[2] = new Vector3(1280,0, 0);
        Target[3] = new Vector3(-640, 0, 0);
    }

    void Update()
    {
        Vector3 target = Target[TargetNum];

        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, target, Time.deltaTime * m_speed);
    }

    public void TargetHome()
    {
        TargetNum = 0;
    }
    public void TargetInventory()
    {
        TargetNum = 1;
    }
    public void TargetShop()
    {
        TargetNum = 2;
    }

    public void TargetDungeon()
    {
        TargetNum = 0;
        WolrdMaps.SetActive(true);
    }
    public void TargetRanking()
    {
        TargetNum = 0;
        Ranking.SetActive(true);
    }

}
