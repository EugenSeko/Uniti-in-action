using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //импорт инфраструктуры для работы с кодом UI.

public class UIController : MonoBehaviour {

    [SerializeField] private Text scoreLabel;//объект сцены Reference Text, предназначенный для задания свойства text.
    [SerializeField] private SettingsPopup settingsPopup;
    private int _score;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);//объявляем какой метод отвечает на событие ENEMY_HIT.
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);//при разрушении объекта удаляем подписчика, чтобы избежать ошибок.
    }

    private void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString();//присвоение переменной _score начального значения.
        settingsPopup.Close();//закрываем всплывающее окно в момент начала игры.
    }
    private void OnEnemyHit()
    {
        _score += 1;//увеличение переменной _score на 1 в ответ на данное событие.
        scoreLabel.text = _score.ToString();
    }

    public void OnOpenSettings()//метод вызываемый кнопкой настроек.
    {
        settingsPopup.Open();
    }
    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
    
}
