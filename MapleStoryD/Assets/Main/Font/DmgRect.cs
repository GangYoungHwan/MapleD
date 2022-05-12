using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DmgRect : MonoBehaviour
{
    public int _Dmg = 0;
    public float _Rectsize = 0f;
    public float _speed = 0.5f;
    public float _alphaSpeed = 0.8f;
    public Text[] _DmgText = null;
    Color alpha;
    void Start()
    {
        alpha = _DmgText[0].color;
        string _DmgStr = _Dmg.ToString();
        for (int i=0; i< _DmgText.Length; i++)
        {
            if(i<_DmgStr.Length)
            {
                _DmgText[i].gameObject.SetActive(true);
                _DmgText[i].text = _DmgStr[i].ToString();
                _Rectsize += 30f;
            }
            else
            {
                _DmgText[i].gameObject.SetActive(false);
            }
        }
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(_Rectsize, 100f);
    }

    void Update()
    {
        transform.position += Vector3.up* _speed * Time.deltaTime;
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * _alphaSpeed);
        for (int i = 0; i < _DmgText.Length; i++)
        {
            _DmgText[i].color = alpha;
        }
    }
}
