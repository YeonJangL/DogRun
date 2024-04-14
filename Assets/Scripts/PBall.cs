using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PBall : MonoBehaviour
{
    public float Speed = 4.0f;
    public int Attack = 10;
    public GameObject effect;

    // Update is called once per frame
    void Update()
    {
        // 미사일 아래쪽 방향으로 움직이기
        // 아래 방향 * 스피드 * 타임
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    // 화면 밖으로 나갈 경우
    private void OnBecameInvisible()
    {
        // 자기 자신 지우기
        Destroy(gameObject);
    }

    // 충돌 처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // 아이템 생성하고 전달
            //collision.gameObject.GetComponent<Monster>().ItemDrop();

            // 몬서터 삭제
            //Destroy(collision.gameObject);

            collision.gameObject.GetComponent<Enemy>().Damage(Attack);

            // 대미지 주기

            // 이펙트 생성
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            // 1초 뒤에 지우기
            Destroy(go, 0.2f);

            // 미사일 삭제
            Destroy(gameObject);
        }

        /*if (collision.CompareTag("Boss"))
        {
            // 이펙트 생성
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            // 1초 뒤에 지우기
            Destroy(go, 1);

            // 미사일 삭제
            Destroy(gameObject);
        }*/
    }
}