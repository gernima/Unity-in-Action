using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingsPopup settings;

    private int _score;
    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    private void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString();
        settings.Close();
    }
    void OnEnemyHit()
    {
        _score += 1;
        scoreLabel.text = _score.ToString();
    }
    
    public void OnOpenSettings()
    {
        settings.Open();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool isShowing = settings.gameObject.activeSelf;
            settings.gameObject.SetActive(!isShowing);

            if (isShowing)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            } else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
