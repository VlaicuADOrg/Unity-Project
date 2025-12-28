using UnityEngine;

public class PlayerMapIcon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private RectTransform mapRect;
    [SerializeField] private RectTransform playerIcon;

    private float minX, maxX, minZ, maxZ;
    private bool hasTerrain;

    void Start()
    {
        Terrain terrain = Terrain.activeTerrain;
        if (terrain == null) return;

        hasTerrain = true;

        Vector3 terrainPos = terrain.transform.position;
        Vector3 terrainSize = terrain.terrainData.size;

        minX = terrainPos.x;
        maxX = terrainPos.x + terrainSize.x;

        minZ = terrainPos.z;
        maxZ = terrainPos.z + terrainSize.z;
    }

    void Update()
    {
        if (player == null || playerIcon == null || mapRect == null || !hasTerrain)
            return;

        Vector3 pos = player.position;

        float normalizedX = Mathf.InverseLerp(minX, maxX, pos.x);
        float normalizedZ = Mathf.InverseLerp(minZ, maxZ, pos.z);

        float mapWidth = mapRect.rect.width;
        float mapHeight = mapRect.rect.height;

        playerIcon.anchoredPosition = new Vector2(
            normalizedX * mapWidth - mapWidth / 2f,
            normalizedZ * mapHeight - mapHeight / 2f
        );
    }
}
