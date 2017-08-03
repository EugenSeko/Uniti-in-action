using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController1 : MonoBehaviour {
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2.0f;
    public const float offsetY = 2.5f;
    private int _score = 0;
    private int _attempts = 0;

    [SerializeField] private MemoryCards originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMesh scoreLabel;
    [SerializeField] private TextMesh attemptsLabel;

	void Start () {
        Vector3 startPos = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        for(int i=0; i< gridCols; i++)
        {
            for(int j=0; j < gridRows; j++)
            {
                MemoryCards card;
                if(i==0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                  card =  Instantiate(originalCard) as MemoryCards;
                }
                // int id = Random.Range(0, images.Length);
                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float posX = (offsetX*i) + startPos.x;
                float posY = -(offsetY*j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }


        
	}
    private int[] ShuffleArray(int[] numbers)  //реализация алгоритма тасования Кнута.
    {
        int[]newArray=numbers.Clone()as int[];
        for(int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    private MemoryCards _firstRevealed;
    private MemoryCards _secondRevealed;
    public bool canReveal //функция чтения, которая возвращает false, если вторая карта уже открыта.
    {
        get
        {
            return _secondRevealed == null;
        }
    }
    public void CardRevealed(MemoryCards card)
    {
        if (_firstRevealed == null) //сохранение карт в одной из двух переменных, в зависимости от того какая из них свободна.
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            // Debug.Log("Match ?.." + (_secondRevealed.id == _firstRevealed.id));//сравнение идентификаторов двух открытых карт.
            StartCoroutine(CheckMatch());//вызывает сопрограмму после открытия двух карт.
        }
    }
    private IEnumerator CheckMatch()
    {
        _attempts++; // подсчет попыток.
        if (_secondRevealed.id == _firstRevealed.id)
        {
            _score++;//увеличиваем счет на единицу, если идентификаторы двух карт совпадают.
            scoreLabel.text = "Score : " + _score;//отображаемый текст - это задаваемое свойство текстовых объектов.
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            _firstRevealed.Unreveal();//закрытие несовпадающих карт.
            _secondRevealed.Unreveal();
        }
        _firstRevealed = null;  //очистка переменных вне зависимости от того было ли совпадение.
        _secondRevealed = null;
        attemptsLabel.text = "Attempts : " + _attempts; //отображаемый текст - это задаваемое свойство текстовых объектов. 
    }
    public void Restart()
    {
        Application.LoadLevel("Memory2D");//эта команда загружает ресурс сцену Memory2D.
    }
    public void Switch()
    {
        Application.LoadLevel("main");
    }
}
