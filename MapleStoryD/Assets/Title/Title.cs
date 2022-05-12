using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public AudioClip _nxSound;
    public AudioClip _wizetSound;
    
    AudioSource Bgm;
    private void Awake()
    {
        Bgm = gameObject.GetComponent<AudioSource>();
    }
    
    void SceneChange()
    {
        SceneManager.LoadScene("CharacterSelectScene");
    }

    void NexonSound()
    {
        Bgm.clip = _nxSound;
        Bgm.Play();
    }

    void WizetSound()
    {
        Bgm.clip = _wizetSound;
        Bgm.Play();
    }
}
