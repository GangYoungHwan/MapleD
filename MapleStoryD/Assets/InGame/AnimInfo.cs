using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimInfo : MonoBehaviour
{
    [SerializeField] private GameObject GameOverinfo = null;
    public void InfoAnim()
    {
        GameOverinfo.SetActive(true);
    }
}
