using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class User : MonoBehaviour
{
    public GameObject Tank1;
    public GameObject Tank2;
    public GameObject Grid;
    public GameObject GameUi;
    public GameObject StartMenu;


    public Image hpBar;
    public float speed;
    public float rotationSpeed;
    public int hp;
    public int damage;
    public int sheld;
    public float reload;
    public Text scoreRed;
    public Text scoreBlue;
    public int score1 = 0;
    public int score2 = 0;

    public KeyCode up;
    public KeyCode down;
    public KeyCode right;
    public KeyCode left;
    public KeyCode shoot;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] Transform posCreatBullet;
    [SerializeField] private PlayMode2 playMode;

    [SerializeField] Color teamColor;
    // Start is called before the first frame update
    void Start()
    {
        Quaternion rotation = Quaternion.Euler(0, 30, 0);
        hpBar.color = teamColor;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
        if (score1 >= 7 || score2 >= 7)
        {
            score1 = 0;
            score2 = 0;
            scoreRed.text = "";
            scoreBlue.text = "";
            Tank1.SetActive(false);
            Tank2.SetActive(false);
            Grid.SetActive(false);
            GameUi.SetActive(false);
            StartMenu.SetActive(true);
        }
    }
    void Move()
    {
        if (Input.GetKey(up))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(down))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(left))
        {
            transform.rotation *= Quaternion.Euler(0, 0, 1 * rotationSpeed);
        }
        if (Input.GetKey(right))
        {
            transform.rotation *= Quaternion.Euler(0, 0, -1 * rotationSpeed);
        }
    }
    public void TakeDamage(int damage)
    {
        if (sheld > damage)
        {
            sheld -= damage;
            return;
        }
        else
        {
            damage -= sheld;
            sheld = 0;
            hp -= damage;

            hpBar.fillAmount = hp * 0.01f;
            if (hp <= 0f)
            {
                gameObject.SetActive(false);
                if (gameObject.tag == "Player")
                {
                    score1++;
                    scoreBlue.text = score1.ToString();
                }
                else
                {
                    score2++;
                    scoreRed.text = score2.ToString();
                }
                playMode.StartGameMode2();
            }
        }
    }

    public void Restart(){
        hp = 100;
        sheld = 25;
        hpBar.fillAmount = 100;
        }

    void Shoot()
    {
        if (Input.GetKeyDown(shoot))
        {           
            Quaternion rotationBullet = transform.rotation;
            GameObject clone = Instantiate(bulletPrefab, posCreatBullet.position, transform.rotation * Quaternion.Euler(0, 0, -180));
            clone.AddComponent<Bullet>();
            clone.GetComponent<Bullet>().speed = bulletSpeed;
            clone.GetComponent<Bullet>().damage = damage;
            clone.GetComponent<Bullet>().parent = gameObject;
            clone.GetComponent<SpriteRenderer>().color = teamColor;
        }
    }

}
