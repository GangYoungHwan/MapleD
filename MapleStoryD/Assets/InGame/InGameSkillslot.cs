using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSkillslot : MonoBehaviour
{
    [SerializeField] int _slotNumber = 0;
    private SpriteRenderer _icon = null;
    void Start()
    {
        _icon = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (InGameManager.Instance.skillList[_slotNumber]._slot == false)
        {
            string path = "Sprite/SkillIcon/Slot";
            _icon.sprite = Resources.Load<Sprite>(path);
        }
        else
        {
            string path = "Sprite/SkillIcon/" + InGameManager.Instance.skillList[_slotNumber]._skillID;
            _icon.sprite = Resources.Load<Sprite>(path);
        }

    }
}
