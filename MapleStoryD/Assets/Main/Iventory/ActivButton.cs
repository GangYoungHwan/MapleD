using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ActivButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Name = null;
    [SerializeField] private Image LineImage = null;
    [SerializeField] private int SkillType = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DataManager.Instance.SkillType== SkillType)
        {
            Name.color = new Color(1f, 1f, 1f);
            LineImage.color = new Color(1f, 1f, 1f);
        }
        else
        {
            Name.color = new Color(130/255f, 130 / 255f, 130 / 255f);
            LineImage.color = new Color(130 / 255f, 130 / 255f, 130 / 255f);
        }
    }
    public void ActiveButton()
    {
        DataManager.Instance.SkillType = 0;
    }
    public void PassiveButton()
    {
        DataManager.Instance.SkillType = 1;
    }
}
