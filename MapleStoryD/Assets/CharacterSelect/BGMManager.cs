using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance = null;
    GameObject BackgroundMusic;
    public float Volume;
    public AudioSource backmusic;
    public AudioClip BtMouseClick;
    private void Awake()
    {
        Volume = 50.0f;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
        if (backmusic.isPlaying) return; //배경음악이 재생되고 있다면 패스
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(BackgroundMusic); //배경음악 계속 재생하게(이후 버튼매니저에서 조작)
        }
    }

    public void BackGroundMusicOffButton() //배경음악 키고 끄는 버튼
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
        backmusic.volume = Volume;
        if (backmusic.isPlaying) backmusic.Pause();
        else backmusic.Play();
    }

    public void BtMouseClickSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(BtMouseClick);
        audio.Play();
    }
}
