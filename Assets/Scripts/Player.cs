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

    // 대왕 뼈다귀
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

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Abs(Input.GetAxis("Vertical")))
        {
            // 좌우 이동일 때만 애니메이션 설정
            if (Input.GetAxis("Horizontal") <= -0.2f)
            {
                ani.SetBool("left", true);
            }
            else
            {
                ani.SetBool("left", false);
            }

            if (Input.GetAxis("Horizontal") >= 0.2)
            {
                ani.SetBool("right", true);
            }
            else
            {
                ani.SetBool("right", false);
            }
        }

        else
        {
            // 상하 이동일 때 애니메이션을 비활성화
            ani.SetBool("left", false);
            ani.SetBool("right", false);
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) > Mathf.Abs(Input.GetAxis("Horizontal")))
        {
            // 상하 이동일 때만 이동 처리
            transform.Translate(0, moveY, 0);
        }
        else
        {
            // 좌우 이동일 때만 이동 처리
            transform.Translate(moveX, 0, 0);
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
                // 대왕 뼈다귀 투척
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

        // 캐릭터의 월드 좌표를 뷰포트 좌표계로 변환
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); // x 값을 0이상 1이하로 제한
        viewPos.y = Mathf.Clamp01(viewPos.y); // y 값을 0이상 1이하로 제한
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); // 다시 월드 좌표로 변환
        transform.position = worldPos; // 좌표 적용
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
