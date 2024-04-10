using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    Animator ani;

    public Transform pos = null;

    public List<GameObject> bone = new List<GameObject>();

    public int skillpower = 0;
    private int Gold = 0;

    // ��� ���ٱ�
    public GameObject Bigbone;
    public float gValue = 0;
    public Image Gage;

    public Text goldText;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") <= -0.2f)
        {
            ani.SetBool("left", true);
        }
        else
        {
            ani .SetBool("left", false);
        }

        if (Input.GetAxis("Horizontal") >= 0.2)
        {
            ani.SetBool("right", true);
        }
        else
        {
            ani.SetBool("right", false);
        }

        if (Input.GetAxis("Vertical") >= 0.2f)
        {
            ani.SetBool("up", true);
        }
        else
        {
            ani.SetBool("up", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bone[skillpower], pos.position, Quaternion.identity);
        }

        else if (Input.GetKey(KeyCode.F))
        {
            gValue += Time.deltaTime;
            Gage.fillAmount = gValue;

            if (gValue >= 1)
            {
                // ��� ���ٱ� ��ô
                GameObject go = Instantiate(Bigbone, pos.position, Quaternion.identity);

                Destroy(go, 3);
                gValue = 0;
            }
        }
        else
        {
            gValue -= Time.deltaTime;
            if (gValue <= 0)
            {
                gValue = 0;
            }

            Gage.fillAmount = gValue;
        }

        transform.Translate(moveX, moveY, 0);

        // ĳ������ ���� ��ǥ�� ����Ʈ ��ǥ��� ��ȯ
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); // x ���� 0�̻� 1���Ϸ� ����
        viewPos.y = Mathf.Clamp01(viewPos.y); // y ���� 0�̻� 1���Ϸ� ����
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); // �ٽ� ���� ��ǥ�� ��ȯ
        transform.position = worldPos; // ��ǥ ����
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Apple")
        {
            Gold += 1;
            goldText.text = Gold.ToString();
        }

        Destroy(collision.gameObject);
    }
}
