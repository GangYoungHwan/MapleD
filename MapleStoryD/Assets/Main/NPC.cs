using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    public RectTransform Tag;
    public Text Name;

    void Start()
    {
        NickNameSize();
    }

    private void Update()
    {
    }

    void NickNameSize()
    {
        var RectSize = Tag.sizeDelta;
        RectSize.x = Name.preferredWidth+5;
        Tag.sizeDelta = RectSize;
    }
}
