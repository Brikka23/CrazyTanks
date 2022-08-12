using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class User : MonoBehaviour
{
    public Image hpBar;
    public float speed;
    public float rotationSpeed;
    public int hp;
    public int damage;
    public int sheld;
    public float reload;

    public KeyCode up;
    public KeyCode down;
    public KeyCode right;
    public KeyCode left;
    public KeyCode shoot;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] Transform posCreatBullet;

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

            if (hp <= 0f)
            {
                gameObject.SetActive(false);               
            }
        }
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
