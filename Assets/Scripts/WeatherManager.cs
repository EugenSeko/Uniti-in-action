﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour, IGameManager {


    public ManagerStatus status { get; private set; }

    private NetworkService _network;//сюда добавляется значение облачности.

    public void Startup(NetworkService service)
    {
        Debug.Log("Weather manager starting...");
        _network = service;//сохранение вставленного объекта NetworkService.
        StartCoroutine(_network.GetWeatherXML(OnXMLDataLoaded));
        status = ManagerStatus.Initializing;
    }
    public void OnXMLDataLoaded(string data)
    {
        Debug.Log(data);
        status = ManagerStatus.Started;
    }
}
