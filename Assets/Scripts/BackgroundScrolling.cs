using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundScrolling : MonoBehaviour
{
    public Tilemap backgroundTilemapPrefab; // ��� Ÿ�ϸ� �������� �����ɴϴ�.
    public Transform player; // �÷��̾��� Transform�� �����ɴϴ�.
    public float scrollSpeed = 1f; // ��� ��ũ�� �ӵ��� �����մϴ�.

    private Vector3 lastPlayerPosition; // �÷��̾��� ���� ��ġ�� �����մϴ�.
    private Tilemap currentTilemap; // ���� ��� ���� Ÿ�ϸ��� �����մϴ�.
    private Tilemap nextTilemap; // ������ ����� Ÿ�ϸ��� �����մϴ�.
    private float tileSizeY; // Ÿ�ϸ��� ���̸� �����մϴ�.

    void Start()
    {
        lastPlayerPosition = player.position;
        tileSizeY = backgroundTilemapPrefab.size.y * backgroundTilemapPrefab.transform.localScale.y;
        InitializeTilemaps();
    }

    void InitializeTilemaps()
    {
        // �ʱ� Ÿ�ϸ��� �����մϴ�.
        currentTilemap = Instantiate(backgroundTilemapPrefab, transform.position, Quaternion.identity);

        // ���� Ÿ�ϸ��� �����մϴ�.
        nextTilemap = Instantiate(backgroundTilemapPrefab, transform.position + Vector3.up * tileSizeY, Quaternion.identity);
    }

    void Update()
    {
        // �÷��̾��� �̵����� ����մϴ�.
        Vector3 playerMovement = player.position - lastPlayerPosition;

        // ����� ��ũ���մϴ�.
        currentTilemap.transform.position -= playerMovement * scrollSpeed;
        nextTilemap.transform.position -= playerMovement * scrollSpeed;

        // �÷��̾��� �̵� �� ��ġ�� �����մϴ�.
        lastPlayerPosition = player.position;

        // ���� Ÿ�ϸ��� ���� Ÿ�ϸ��� ���� �̾ ��ġ�մϴ�.
        if (player.position.y > currentTilemap.transform.position.y + tileSizeY)
        {
            SwapTilemaps();
        }
    }

    void SwapTilemaps()
    {
        // ���� Ÿ�ϸʰ� ���� Ÿ�ϸ��� ��ü�մϴ�.
        Tilemap temp = currentTilemap;
        currentTilemap = nextTilemap;
        nextTilemap = temp;

        // ���� Ÿ�ϸ��� ���� Ÿ�ϸ��� ���� �̾ ��ġ�մϴ�.
        nextTilemap.transform.position = currentTilemap.transform.position + Vector3.up * tileSizeY;
    }
}