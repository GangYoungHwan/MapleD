using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButton : MonoBehaviour
{
    [SerializeField] private GameObject _MenuBar = null;
    [SerializeField] private GameObject _Setting = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MenuButton()
    {
        if(_MenuBar.activeSelf)
            _MenuBar.SetActive(false);
        else
            _MenuBar.SetActive(true);
    }
    public void SettingButton()
    {
        _Setting.SetActive(true);
    }
}
