using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    [SerializeField] private InputField nameInputField;
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
}
