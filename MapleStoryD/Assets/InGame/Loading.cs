using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{
    private Image loadingImage = null;
    float _alphaSpeed = 0.5f;
    Color alpha;
    void Start()
    {
        loadingImage = GetComponent<Image>();
        alpha = loadingImage.color;
    }
    private void Update()
    {
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * _alphaSpeed);
        loadingImage.color = alpha;
        if (alpha.a <= 0)
            Destroy(gameObject);
    }
}
