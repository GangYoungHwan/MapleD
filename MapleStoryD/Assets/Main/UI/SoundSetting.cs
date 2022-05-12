using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundSetting : MonoBehaviour
{
    [SerializeField] private Slider _BGM = null;
    [SerializeField] private Slider _SFX = null;
    [SerializeField] private Toggle _BGMToggle = null;
    [SerializeField] private Toggle _SFXToggle = null;
    private void OnEnable()
    {
        _BGM.value = SoundManager.Instance.masterVolumeBGM;
        _SFX.value = SoundManager.Instance.masterVolumeSFX;
        _BGMToggle.isOn = SoundManager.Instance.masterBGM;
        _SFXToggle.isOn = SoundManager.Instance.masterSFX;
    }

    // Update is called once per frame
    void Update()
    {
        _BGM.maxValue = 1f;
        _SFX.maxValue = 1f;
        SoundManager.Instance.masterVolumeBGM = _BGM.value;
        SoundManager.Instance.masterVolumeSFX = _SFX.value;
        SoundManager.Instance.bgmPlayer.volume = _BGM.value;
        SoundManager.Instance.sfxPlayer.volume = _SFX.value;
        if (_BGMToggle.isOn)
        {
            SoundManager.Instance.bgmPlayer.volume = 0f;
            SoundManager.Instance.masterBGM = true;
        }
        else
            SoundManager.Instance.masterBGM = false;
        if (_SFXToggle.isOn)
        {
            SoundManager.Instance.sfxPlayer.volume = 0f;
            SoundManager.Instance.masterSFX = true;
        }
        else
            SoundManager.Instance.masterSFX = false;
    }

    public void ButtonClose()
    {
        SoundManager.Instance.SaveSoundDataToJson();
        this.gameObject.SetActive(false);
    }
}
