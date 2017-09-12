using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NetworkService{

   // private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?q=Chicago,us&mode=xml";
    private const string xmlApi = "http://api.apixu.com/v1/current.xml?key=74344f16a90c49f48ea175644171209&q=Dnepropetrovsk";


    private bool IsResponseValid(WWW www)//проверка ответа на наличие ошибок.
    {
        if (www.error != null)
        {
            Debug.Log("bad connection");
            Debug.Log(www.error);
            return false;
        }
        else if (string.IsNullOrEmpty(www.text))
        {
            Debug.Log("bad data");
            return false;
        }
        else { return true;} 
    }

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        WWW www = new WWW(url);//HTTP запрос, отправленный путем создания веб-объекта.
        yield return www;//пауза в процессе скачивания.
        if (!IsResponseValid(www))//прерывание сопрограммы в случае ошибки.
        {
            yield break;
        }
        callback(www.text);//делегат может быть вызван так же, как и исходная функция.
    }
    public IEnumerator GetWeatherXML(Action<string> callback)
    {
        return CallAPI(xmlApi, callback);// Каскад ключевых слов yield в вызывающих друг друга методах сопрограммы.
    }

}
