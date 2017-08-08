﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour {

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
    }
}
