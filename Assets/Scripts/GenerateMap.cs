using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public GameObject[] objects;
    public int numberObject; // какое кол-во надо заспавнить
    private int generatedObject = 0;
    public float minRange, maxRange; //территория спавна, у меня она к примеру -50 50

    void Update()
    {
        //считает сколько объектов заспавнено
        if (generatedObject < numberObject)
        {
            Generate();
            generatedObject++;
        }

    }
    //собственно сама генерация 
    public void Generate()
    {
        int rand = Random.Range(0, objects.Length);
        var cell = Instantiate(objects[rand], transform.position, Quaternion.identity);
        cell.transform.position = new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), transform.position.z);

    }
}
