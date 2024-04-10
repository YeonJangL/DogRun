using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 100;
    public float Speed = 3.0f;
    public float Delay = 1.0f;
    public Transform ms;
    public GameObject bullet;

    public GameObject Apple;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(bullet, ms.position, Quaternion.identity);

        // ¿Á±Õ »£√‚
        Invoke("CreateBullet", Delay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void Damage(int attack)
    {
        HP -= attack;

        if (HP <= 0)
        {
            ItemDrop();
            Destroy(gameObject);
        }
    }

    public void ItemDrop()
    {
        Instantiate(Apple, transform.position, Quaternion.identity);
    }
}
