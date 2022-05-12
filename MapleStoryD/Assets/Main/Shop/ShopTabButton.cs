using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopTabButton : MonoBehaviour
{
    Vector3[] Target = new Vector3[3];
    [SerializeField] float m_speed = 0f;
    private int TargetNum = 0;

    [SerializeField] public TextMeshProUGUI SkillText = null;
    [SerializeField] public TextMeshProUGUI ItemText = null;
    [SerializeField] public TextMeshProUGUI AvataText = null;

    [SerializeField] public Image SkillLine = null;
    [SerializeField] public Image ItemLine = null;
    [SerializeField] public Image AvataLine = null;
    void Start()
    {
        DataManager.Instance.SavePlayer(DataManager.Instance.SlotNumber);
        Target[0] = new Vector3(0, 0, 0);
        Target[1] = new Vector3(640, 0, 0);
        Target[2] = new Vector3(1280, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = Target[TargetNum];

        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, -target, Time.deltaTime * m_speed);
        if (TargetNum == 0)
        {
            SkillText.color = new Color(1f,1f,1f);
            SkillLine.color = new Color(1f, 1f, 1f);
        }
        else
        {
            SkillText.color = new Color(130 / 255f, 130 / 255f, 130 / 255f);
            SkillLine.color = new Color(130 / 255f, 130 / 255f, 130 / 255f);
        }

        if (TargetNum == 1)
        {
            ItemText.color = new Color(1f, 1f, 1f);
            ItemLine.color = new Color(1f, 1f, 1f);
        }
        else
        {
            ItemText.color = new Color(130 / 255f, 130 / 255f, 130 / 255f);
            ItemLine.color = new Color(130 / 255f, 130 / 255f, 130 / 255f);
        }

        if (TargetNum == 2)
        {
            AvataText.color = new Color(1f, 1f, 1f);
            AvataLine.color = new Color(1f, 1f, 1f);
        }
        else
        {
            AvataText.color = new Color(130 / 255f, 130 / 255f, 130 / 255f);
            AvataLine.color = new Color(130 / 255f, 130 / 255f, 130 / 255f);
        }
    }

    public void TargetSkillShop()
    {
        TargetNum = 0;
    }
    public void TargetItemShop()
    {
        TargetNum = 1;
    }
    public void TargetAvataShop()
    {
        TargetNum = 2;
    }
}
