using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealtimeMovement : MonoBehaviour {

    [SerializeField] private Transform target; //сценарию нужна ссылка на объект, относительно которого будет происходить перемещение.
    public float rotSpeed = 1.5f;

	void Update () {
        Vector3 movement = Vector3.zero;//начинаем с вектора (0,0,0) непрерывно добавляя компоненты движения.
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        if (horInput != 0 || vertInput != 0)//движение обрабатывается только при нажатии клавиш со стрелками.
        {
            movement.x = horInput;
            movement.z = vertInput;

            Quaternion tmp = target.rotation;//сохраняем начальную ориентацию, чтобы вернуться к ней после завершения работы с целевым объектом.
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);//преобразуем направление движения из локальных в глобальные координаты.
            target.rotation = tmp;

            //transform.rotation = Quaternion.LookRotation(movement);//метод LookRotation вычисляет кватернион смотрящий в этом направлении.
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);//Метод Quaternion.Lerp() выполняет плавный поворот из текущего положения в целевое(третий параметр метода контролирует скорость вращения).
        }

    }
}
