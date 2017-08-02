using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour {


    public float speed = 10;
    public float maxZ = 6;
    public float minZ = -6;
    private int _direction=1;


    void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime*_direction);
        if (transform.position.z >= maxZ || transform.position.z <= minZ)
        {
            _direction *= -1;
            transform.Translate(0, 0, speed * Time.deltaTime * _direction);
        }
    }
}
