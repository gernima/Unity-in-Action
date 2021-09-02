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
}
