using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public float speed = 1f;
    public Transform player;
    public Transform mapPrefab;
    public Transform currentMap;

    private float viewHeight;

    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * 2;
        InitializeMap();
    }

    private void Update()
    {
        MoveMap();
        CheckEndPosition();
    }

    private void InitializeMap()
    {
        currentMap = Instantiate(mapPrefab, Vector3.zero, Quaternion.identity);
    }

    private void MoveMap()
    {
        currentMap.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void CheckEndPosition()
    {
        if (currentMap.position.y < -viewHeight)
        {
            currentMap.Translate(Vector3.up * viewHeight * 2);
        }
    }
}
