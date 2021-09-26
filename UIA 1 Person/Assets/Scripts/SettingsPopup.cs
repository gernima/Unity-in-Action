using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    [SerializeField] private InputField nameInputField;
    [SerializeField] private AudioClip sound;

    private void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
        nameInputField.text = PlayerPrefs.GetString("name", "Player");
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void OnSubmitName(string name)
    {
        PlayerPrefs.SetString("name", name);
    }
    public void OnSpeedValue(float speed)
    {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
        PlayerPrefs.SetFloat("speed", speed);
    }
    public void OnSoundToggle()
    {
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
        Managers.Audio.PlaySound(sound);
    }
    public void OnSoundValue(float volume)
    {
        Managers.Audio.soundVolume = volume;
    }
    public void OnMusicToggle()
    {
        Managers.Audio.musicMute = !Managers.Audio.musicMute;
        Managers.Audio.PlaySound(sound);
    }
    public void OnMusicValue(float volume)
    {
        Managers.Audio.musicVolume = volume;
    }
    public void OnPlayMusic(int selector)
    {
        switch (selector)
        {
            case 1:
                Managers.Audio.PlayIntroMusic();
                break;
            case 2:
                Managers.Audio.PlayLevelMusic();
                break;
            default:
                Managers.Audio.StopMusic();
                break;
        }
    }
}
