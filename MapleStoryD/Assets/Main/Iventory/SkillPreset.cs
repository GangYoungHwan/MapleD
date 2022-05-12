using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillPreset : MonoBehaviour
{
    [SerializeField] private int SlotNumber = 0;
    [SerializeField] private Image Icon = null;
    [SerializeField] private GameObject Empty = null;
    [SerializeField] private GameObject confim = null;
    [SerializeField] private Button _button = null;
    int PresetNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.Instance.SkillType == 0)
        {
            PresetNumber = DataManager.Instance.playerData.SkillActiveSlotID[SlotNumber];
            string path = "Sprite/SkillIcon/" + SlotNumber;
            Icon.sprite = Resources.Load<Sprite>(path);
        }
        else
        {
            PresetNumber = DataManager.Instance.playerData.SkillPassiveSlotID[SlotNumber];
            string path = "Sprite/SkillIcon/" + SlotNumber;
            Icon.sprite = Resources.Load<Sprite>(path);
        }

    }
}
