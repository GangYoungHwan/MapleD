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
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); //������� �����ص�
        if (backmusic.isPlaying) return; //��������� ����ǰ� �ִٸ� �н�
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(BackgroundMusic); //������� ��� ����ϰ�(���� ��ư�Ŵ������� ����)
        }
    }

    public void BackGroundMusicOffButton() //������� Ű�� ���� ��ư
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); //������� �����ص�
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
