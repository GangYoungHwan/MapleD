using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    [SerializeField] private float Pos = 150f;
    public RectTransform Contant;
    public GameObject Arrow;
    void Update()
    {
        if (Contant.localPosition.y > Pos)
            Arrow.gameObject.SetActive(false);
        else
            Arrow.gameObject.SetActive(true);
    }
}
