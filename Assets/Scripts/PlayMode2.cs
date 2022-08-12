using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMode2 : MonoBehaviour
{
    public GameObject[] maps;
    public GameObject Tank1;
    public GameObject Tank2;
    public GameObject Hpbar1;
    public GameObject Hpbar2;
    public GameObject Button;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGameMode2()
    {

        int rand = Random.Range(0,maps.Length);

        Button.SetActive(false);
        Tank1.SetActive(true);
        Tank2.SetActive(true);
        Hpbar1.SetActive(true);
        Hpbar2.SetActive(true);
        maps[rand].SetActive(true);

        switch (rand.ToString())
        {
            case "0":
                Tank1.transform.position = new Vector2(13f, -10f);
                Tank1.transform.Rotate(0f, 0f, 180f);
                Tank2.transform.position = new Vector2(-17.91f, 8.43f);
                Tank2.transform.Rotate(0f, 0f, 90f);
                break;

            case "1":
                Tank1.transform.position = new Vector2(18f, 2f);
                Tank1.transform.Rotate(0f, 0f, -90f);
                Tank2.transform.position = new Vector2(-18f, 2f);
                Tank2.transform.Rotate(0f, 0f, 90f);
                break;

            case "2":
                Tank1.transform.position = new Vector2(18.58f, 8.43f);
                Tank1.transform.Rotate(0f, 0f, 0f);
                Tank2.transform.position = new Vector2(-18.48f, 8.43f);
                Tank2.transform.Rotate(0f, 0f, 0f);
                break;

            case "3":
                Tank1.transform.position = new Vector2(0f, -8f);
                Tank1.transform.Rotate(0f, 0f, 180f);
                Tank2.transform.position = new Vector2(0f, 8f);
                Tank2.transform.Rotate(0f, 0f, 0f);
                break;

            case "4":
                Tank1.transform.position = new Vector2(10.6f, 4.26f);
                Tank1.transform.Rotate(0f, 0f, 0f);
                Tank2.transform.position = new Vector2(-0.5f, 8f);
                Tank2.transform.Rotate(0f, 0f, -90f);
                break;

        }

    }
}
