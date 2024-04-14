using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundScrolling : MonoBehaviour
{
    public Tilemap backgroundTilemapPrefab; // 배경 타일맵 프리팹을 가져옵니다.
    public Transform player; // 플레이어의 Transform을 가져옵니다.
    public float scrollSpeed = 1f; // 배경 스크롤 속도를 설정합니다.

    private Vector3 lastPlayerPosition; // 플레이어의 이전 위치를 저장합니다.
    private Tilemap currentTilemap; // 현재 사용 중인 타일맵을 저장합니다.
    private Tilemap nextTilemap; // 다음에 사용할 타일맵을 저장합니다.
    private float tileSizeY; // 타일맵의 높이를 저장합니다.

    void Start()
    {
        lastPlayerPosition = player.position;
        tileSizeY = backgroundTilemapPrefab.size.y * backgroundTilemapPrefab.transform.localScale.y;
        InitializeTilemaps();
    }

    void InitializeTilemaps()
    {
        // 초기 타일맵을 생성합니다.
        currentTilemap = Instantiate(backgroundTilemapPrefab, transform.position, Quaternion.identity);

        // 다음 타일맵을 생성합니다.
        nextTilemap = Instantiate(backgroundTilemapPrefab, transform.position + Vector3.up * tileSizeY, Quaternion.identity);
    }

    void Update()
    {
        // 플레이어의 이동량을 계산합니다.
        Vector3 playerMovement = player.position - lastPlayerPosition;

        // 배경을 스크롤합니다.
        currentTilemap.transform.position -= playerMovement * scrollSpeed;
        nextTilemap.transform.position -= playerMovement * scrollSpeed;

        // 플레이어의 이동 후 위치를 저장합니다.
        lastPlayerPosition = player.position;

        // 다음 타일맵을 현재 타일맵의 끝에 이어서 배치합니다.
        if (player.position.y > currentTilemap.transform.position.y + tileSizeY)
        {
            SwapTilemaps();
        }
    }

    void SwapTilemaps()
    {
        // 현재 타일맵과 다음 타일맵을 교체합니다.
        Tilemap temp = currentTilemap;
        currentTilemap = nextTilemap;
        nextTilemap = temp;

        // 다음 타일맵을 현재 타일맵의 끝에 이어서 배치합니다.
        nextTilemap.transform.position = currentTilemap.transform.position + Vector3.up * tileSizeY;
    }
}