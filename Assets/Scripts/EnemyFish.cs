using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFish : MonoBehaviour
{
    public float Speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {

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

    // 충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "PBall")
        {
            // 플레이어 지우기

            // 미사일 지우기
            Destroy(gameObject);
        }
        
        Destroy(gameObject, 1.0f);
    }
}
