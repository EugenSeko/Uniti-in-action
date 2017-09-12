using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour {

    [SerializeField] private Material sky;
    [SerializeField] private Light sun;

    private float _fullIntensity;
    private float _cloudValue = 0;


    void Start () {
        _fullIntensity = sun.intensity;//исходная интенсивность света считается полной.

	}
	
	// Update is called once per frame
	void Update () {
        SetOvercast(_cloudValue);
        _cloudValue += .005f;
	}
    private void SetOvercast(float value)//корректируем значение _Blend материала и интенсивность света.
    {
        if (value < 1 )
        {
            sky.SetFloat("_Blend", value);
        }
        if(sun.intensity > 0)
        {
            sun.intensity = _fullIntensity - (_fullIntensity * value);
        }
    }
}
