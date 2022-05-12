using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public void BtMouseClick()
    {
        SoundManager.Instance.PlaySFXSound("BtMouseClick");
    }

}
