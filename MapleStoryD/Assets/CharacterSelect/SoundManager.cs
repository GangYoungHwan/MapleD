using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
[System.Serializable]
public class Sound
{
    public float BGMvolum;
    public float SFXvoium;
    public bool BGM;
    public bool SFX;
}
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }

            return instance;
        }
    } // Sound�� �������ִ� ��ũ��Ʈ�� �ϳ��� �����ؾ��ϰ� instance������Ƽ�� ���� ��𿡼��� �ҷ��������� �̱��� ���

    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;

    public float masterVolumeSFX = 1f;
    public float masterVolumeBGM = 1f;

    public bool masterSFX = false;
    public bool masterBGM = false;

    [SerializeField]
    private AudioClip TitleBgmAudioClip; //ĳ���ͼ���ȭ�� ���� ����� BGM
    [SerializeField]
    private AudioClip mainBgmAudioClip; //����ȭ�鿡�� ����� BGM
    [SerializeField]
    private AudioClip adventureBgmAudioClip; //��庥�ľ����� ����� BGM

    [SerializeField]
    private AudioClip[] sfxAudioClips; //ȿ������ ����

    Dictionary<string, AudioClip> audioClipsDic = new Dictionary<string, AudioClip>(); //ȿ���� ��ųʸ�
    // AudioClip�� Key,Value ���·� �����ϱ� ���� ��ųʸ� ���

    public Sound _Sound;

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject); //���� ������ ����� ��.

        bgmPlayer = GameObject.Find("BGMSoundPlayer").GetComponent<AudioSource>();
        sfxPlayer = GameObject.Find("SFXSoundPlayer").GetComponent<AudioSource>();
        DontDestroyOnLoad(bgmPlayer.gameObject);
        DontDestroyOnLoad(sfxPlayer.gameObject);
        LoadSoundDataToJson();
        foreach (AudioClip audioclip in sfxAudioClips)
        {
            audioClipsDic.Add(audioclip.name, audioclip);
        }
    }

    // ȿ�� ���� ��� : �̸��� �ʼ� �Ű�����, ������ ������ �Ű������� ����
    public void PlaySFXSound(string name, float volume = 1f)
    {
        if (audioClipsDic.ContainsKey(name) == false)
        {
            Debug.Log(name + " is not Contained audioClipsDic");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[name], volume* masterVolumeSFX);
    }

    //BGM ���� ��� : ������ ������ �Ű������� ����
    public void PlayBGMSound(float volume = 1f)
    {
        bgmPlayer.loop = true; //BGM �����̹Ƿ� ��������
        bgmPlayer.volume = volume * masterVolumeBGM;
        if (SceneManager.GetActiveScene().name == "CharacterSelectScene")
        {
            bgmPlayer.clip = TitleBgmAudioClip;
            if (!bgmPlayer.isPlaying) bgmPlayer.Play();
        }
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            bgmPlayer.clip = mainBgmAudioClip;
            if (!bgmPlayer.isPlaying) bgmPlayer.Play();
        }
        //���� ���� �´� BGM ���
    }

    public void SaveSoundDataToJson()
    {
        Sound save = new Sound();
        save.BGMvolum = masterVolumeBGM;
        save.SFXvoium = masterVolumeSFX;
        save.BGM = masterBGM;
        save.SFX = masterSFX;
        string jsonData = JsonUtility.ToJson(save, true);
        string path = Path.Combine(Application.dataPath, "volum.json");
        File.WriteAllText(path, jsonData);
        Debug.Log("���� ������ ���� �Ϸ�");
    }

    public void LoadSoundDataToJson()
    {
        string path = Path.Combine(Application.dataPath, "volum.json");
        string jsonData = File.ReadAllText(path);
        _Sound = JsonUtility.FromJson<Sound>(jsonData);
        masterVolumeBGM = _Sound.BGMvolum;
        masterVolumeSFX = _Sound.SFXvoium;
        masterBGM = _Sound.BGM;
        masterSFX = _Sound.SFX;
        Debug.Log("���� ������ �ε�Ϸ�");
    }
}