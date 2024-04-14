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
        // �̻��� �Ʒ��� �������� �����̱�
        // �Ʒ� ���� * ���ǵ� * Ÿ��
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    // ȭ�� ������ ���� ���
    private void OnBecameInvisible()
    {
        // �ڱ� �ڽ� �����
        Destroy(gameObject);
    }

    // �浹 ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // ������ �����ϰ� ����
            //collision.gameObject.GetComponent<Monster>().ItemDrop();

            // ���� ����
            //Destroy(collision.gameObject);

            collision.gameObject.GetComponent<Enemy>().Damage(Attack);

            // ����� �ֱ�

            // ����Ʈ ����
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            // 1�� �ڿ� �����
            Destroy(go, 0.2f);

            // �̻��� ����
            Destroy(gameObject);
        }

        /*if (collision.CompareTag("Boss"))
        {
            // ����Ʈ ����
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            // 1�� �ڿ� �����
            Destroy(go, 1);

            // �̻��� ����
            Destroy(gameObject);
        }*/
    }
}