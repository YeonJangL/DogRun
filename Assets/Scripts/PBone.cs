using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBone : MonoBehaviour
{
    public GameObject effect;
    Transform pos;
    int Attack = 10;

    // Start is called before the first frame update
    void Start()
    {
        pos = GameObject.Find("Player").GetComponent<Player>().pos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(Attack);

            // 이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            
            // 1초 후 지우기
            Destroy(go, 1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(Attack);

            // 이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);

            Destroy(go, 1);
        }
    }
}
