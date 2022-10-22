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
    public GameObject Grid;
    public User User1;
    public User User2;

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
        Grid.SetActive(true);
        Tank1.SetActive(true);
        Tank2.SetActive(true);
        Hpbar1.SetActive(true);
        Hpbar2.SetActive(true);
        User1.Restart();
        User2.Restart();

        switch (rand.ToString())
        {
            case "0":
                maps[1].SetActive(false);
                maps[2].SetActive(false);
                maps[3].SetActive(false);
                maps[4].SetActive(false);
                maps[0].SetActive(true);
                Tank1.transform.position = new Vector2(13f, -10f);
                Tank1.transform.Rotate(0f, 0f, 180f);
                Tank2.transform.position = new Vector2(-17.91f, 8.43f);
                Tank2.transform.Rotate(0f, 0f, 90f);
                break;

            case "1":
                maps[0].SetActive(false);
                maps[2].SetActive(false);
                maps[3].SetActive(false);
                maps[4].SetActive(false);
                maps[1].SetActive(true);
                Tank1.transform.position = new Vector2(18f, 2f);
                Tank1.transform.Rotate(0f, 0f, -90f);
                Tank2.transform.position = new Vector2(-18f, 2f);
                Tank2.transform.Rotate(0f, 0f, 90f);
                break;

            case "2":
                maps[1].SetActive(false);
                maps[0].SetActive(false);
                maps[3].SetActive(false);
                maps[4].SetActive(false);
                maps[2].SetActive(true);
                Tank1.transform.position = new Vector2(18.58f, 8.43f);
                Tank1.transform.Rotate(0f, 0f, 0f);
                Tank2.transform.position = new Vector2(-18.48f, 8.43f);
                Tank2.transform.Rotate(0f, 0f, 0f);
                break;

            case "3":
                maps[1].SetActive(false);
                maps[2].SetActive(false);
                maps[0].SetActive(false);
                maps[4].SetActive(false);
                maps[3].SetActive(true);
                Tank1.transform.position = new Vector2(0f, -8f);
                Tank1.transform.Rotate(0f, 0f, 180f);
                Tank2.transform.position = new Vector2(0f, 8f);
                Tank2.transform.Rotate(0f, 0f, 0f);
                break;

            case "4":
                maps[1].SetActive(false);
                maps[2].SetActive(false);
                maps[3].SetActive(false);
                maps[0].SetActive(false);
                maps[4].SetActive(true);
                Tank1.transform.position = new Vector2(10.6f, 4.26f);
                Tank1.transform.Rotate(0f, 0f, 0f);
                Tank2.transform.position = new Vector2(-0.5f, 8f);
                Tank2.transform.Rotate(0f, 0f, -90f);
                break;

        }

    }
}
