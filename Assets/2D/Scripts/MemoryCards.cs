﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCards : MonoBehaviour {

    [SerializeField] private GameObject cardBack;
    [SerializeField] private SceneController1 controller;

    private int _id;
    public int id
    {
        get
        {
            return _id;
        }
    }

    public void SetCard(int id,Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void OnMouseDown()
    {
        if (cardBack.activeSelf && controller.canReveal)//проверка свойств canReveal контроллера, позволяющая гарантировать, что открыты могут быть только две карты.
        {
            cardBack.SetActive(false);
            controller.CardRevealed(this);//уведомление контроллера при открытии этой карты.
        }
    } 
    public void Unreveal()//открытый метод позволяющий SceneController1 снова скрыть карту(вернув на место спрайт card_back).
    {
        cardBack.SetActive(true);
    }
}
