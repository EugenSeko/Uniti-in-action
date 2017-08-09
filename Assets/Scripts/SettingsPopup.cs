using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsPopup : MonoBehaviour {

    [SerializeField] private Slider speedSlider;

    public void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
    }

    public void Open()
    {
        gameObject.SetActive(true);//активируем этот объект, чтобы открыть окно.
    }
    public void Close()
    {
        gameObject.SetActive(false);//деактивируем объект, чтобы закрыть окно.
    }
    public void OnSubmitName(string name)//этот метод срабатывает в момент начала ввода данных в текстовое поле.
    {
        Debug.Log(name);
    }
    public void OnSpeedValue(float speed)
    {
        Debug.Log("Speed " + speed);
        PlayerPrefs.SetFloat("speed", speed);
    }
}
