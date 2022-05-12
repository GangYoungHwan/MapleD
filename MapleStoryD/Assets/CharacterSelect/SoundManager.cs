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
    } // Sound를 관리해주는 스크립트는 하나만 존재해야하고 instance프로퍼티로 언제 어디에서나 불러오기위해 싱글톤 사용

    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;

    public float masterVolumeSFX = 1f;
    public float masterVolumeBGM = 1f;

    public bool masterSFX = false;
    public bool masterBGM = false;

    [SerializeField]
    private AudioClip TitleBgmAudioClip; //캐릭터선택화면 에서 사용할 BGM
    [SerializeField]
    private AudioClip mainBgmAudioClip; //메인화면에서 사용할 BGM
    [SerializeField]
    private AudioClip adventureBgmAudioClip; //어드벤쳐씬에서 사용할 BGM

    [SerializeField]
    private AudioClip[] sfxAudioClips; //효과음들 지정

    Dictionary<string, AudioClip> audioClipsDic = new Dictionary<string, AudioClip>(); //효과음 딕셔너리
    // AudioClip을 Key,Value 형태로 관리하기 위해 딕셔너리 사용

    public Sound _Sound;

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject); //여러 씬에서 사용할 것.

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

    // 효과 사운드 재생 : 이름을 필수 매개변수, 볼륨을 선택적 매개변수로 지정
    public void PlaySFXSound(string name, float volume = 1f)
    {
        if (audioClipsDic.ContainsKey(name) == false)
        {
            Debug.Log(name + " is not Contained audioClipsDic");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[name], volume* masterVolumeSFX);
    }

    //BGM 사운드 재생 : 볼륨을 선택적 매개변수로 지정
    public void PlayBGMSound(float volume = 1f)
    {
        bgmPlayer.loop = true; //BGM 사운드이므로 루프설정
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
        //현재 씬에 맞는 BGM 재생
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
        Debug.Log("사운드 데이터 저장 완료");
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
        Debug.Log("사운드 데이터 로드완료");
    }
}