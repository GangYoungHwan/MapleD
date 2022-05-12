using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClose : MonoBehaviour
{
    public void OnButtonClose()
    {
        this.gameObject.SetActive(false);
    }
}
