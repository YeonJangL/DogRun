using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // ������ ���� �ӵ�
    public float ItemVelocity = 20f;
    Rigidbody2D rig = null;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
