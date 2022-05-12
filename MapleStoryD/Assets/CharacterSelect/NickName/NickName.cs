using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NickName : MonoBehaviour
{
    public int SlotNumber;
    public GameObject Left;
    public RectTransform Middle;
    public GameObject Right;

    public Text Name;

    void Start()
    {

    }

    private void Update()
    {
        NickNameSize(SlotNumber);
    }

    void NickNameSize(int SlotNum)
    {
        if(SlotNum == 1)
            Name.text = DataManager.Instance.playerData_1.Name;
        else if(SlotNum == 2)
            Name.text = DataManager.Instance.playerData_2.Name;
        else if (SlotNum == 3)
            Name.text = DataManager.Instance.playerData_3.Name;
        else if (SlotNum == 4)
            Name.text = DataManager.Instance.playerData_4.Name;
        var RectSize = Middle.sizeDelta;
        RectSize.x = Name.preferredWidth;
        Middle.sizeDelta = RectSize;
        RectTransform LeftRect = Left.GetComponent<RectTransform>();
        RectTransform RightRect = Right.GetComponent<RectTransform>();
        Vector3 Leftpos = new Vector3(-(LeftRect.sizeDelta.x / 2) - (Middle.sizeDelta.x / 2), Middle.transform.localPosition.y, 0);
        Left.transform.localPosition = Leftpos;
        Vector3 Rightpos = new Vector3((RightRect.sizeDelta.x / 2) + (Middle.sizeDelta.x / 2), Middle.transform.localPosition.y, 0);
        Right.transform.localPosition = Rightpos;
    }
}
