using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharCreate : MonoBehaviour
{
    public GameObject confirn;
    private void Awake()
    {
        
    }
    public void Start()
    {
        SoundManager.Instance.PlayBGMSound();
    }
    public void SceneChange()
    {
        SoundManager.Instance.PlaySFXSound("ScrollUp");
        SceneManager.LoadScene("CreateScene");
    }

    public void Common()
    {
        SoundManager.Instance.PlaySFXSound("ScrollUp");
        SceneManager.LoadScene("CharacterSelectScene");
    }

    public void CharaterCreate()
    {
        confirn.SetActive(true);
    }

    public void CharaterCreateNo()
    {
        confirn.SetActive(false);
    }

}
