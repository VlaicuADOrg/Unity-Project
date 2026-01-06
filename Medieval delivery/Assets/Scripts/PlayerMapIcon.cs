using UnityEngine;

public class PlayerMapIcon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private RectTransform mapRect;
    [SerializeField] private RectTransform playerIcon;

    [Header("World bounds source")]
    [SerializeField] private bool useCustomWorldBounds = true;
    [SerializeField] private Transform worldBottomLeft;
    [SerializeField] private Transform worldTopRight;

    [Header("Mapping fixes (try these if icon is mirrored/rotated)")]
    [SerializeField] private bool swapXZ = false;
    [SerializeField] private bool invertX = false;
    [SerializeField] private bool invertY = false;

    [Tooltip("Rotate the map coordinates around center. Use 0, 90, 180, 270.")]
    [SerializeField] private float mapRotationDegrees = 0f;

    [Header("Fine tuning (0..1 space)")]
    [SerializeField] private Vector2 normalizedOffset = Vector2.zero; 
    [SerializeField] private Vector2 normalizedScale = Vector2.one;   

    [Header("Debug")]
    [SerializeField] private bool debugLogs = true;
    [SerializeField] private float debugEverySeconds = 0.5f;

    private float minX, maxX, minZ, maxZ;
    private bool hasBounds;

    private Terrain _cachedTerrain;
    private float _nextDebugTime;

    private void Start()
    {
        TryAutoAssignPlayer();
        CacheBounds();
    }

    private void OnEnable()
    {
        CacheBounds();
        _nextDebugTime = 0f;
    }

    private void TryAutoAssignPlayer()
    {
        if (player != null) return;

        var go = GameObject.FindGameObjectWithTag("Player");
        if (go != null) player = go.transform;
        else Debug.LogWarning("PlayerMapIcon: Player not assigned and no GameObject with tag 'Player' found.");
    }

    private Terrain GetTerrainForPlayer(Vector3 p)
    {
        var terrains = Terrain.activeTerrains;
        if (terrains != null && terrains.Length > 0)
        {
            foreach (var t in terrains)
            {
                if (!t || t.terrainData == null) continue;

                Vector3 tp = t.transform.position;
                Vector3 ts = t.terrainData.size;

                bool inside =
                    p.x >= tp.x && p.x <= tp.x + ts.x &&
                    p.z >= tp.z && p.z <= tp.z + ts.z;

                if (inside) return t;
            }
        }

        return Terrain.activeTerrain;
    }

    private void CacheBounds()
    {
        hasBounds = false;
        _cachedTerrain = null;

        if (useCustomWorldBounds)
        {
            if (worldBottomLeft == null || worldTopRight == null)
            {
                Debug.LogWarning("PlayerMapIcon: useCustomWorldBounds is ON but corners are not assigned.");
            }
            else
            {
                minX = worldBottomLeft.position.x;
                minZ = worldBottomLeft.position.z;
                maxX = worldTopRight.position.x;
                maxZ = worldTopRight.position.z;

                hasBounds = true;

                if (debugLogs)
                {
                    Debug.Log(
                        $"[PlayerMapIcon] Using CUSTOM bounds:\n" +
                        $"  BottomLeft world: {worldBottomLeft.position}\n" +
                        $"  TopRight world:   {worldTopRight.position}\n" +
                        $"  Bounds X: {minX} -> {maxX}, Z: {minZ} -> {maxZ}"
                    );
                }
                return;
            }
        }

        Terrain t2 = (player != null) ? GetTerrainForPlayer(player.position) : Terrain.activeTerrain;
        if (t2 == null || t2.terrainData == null)
        {
            Debug.LogError("PlayerMapIcon: NO ACTIVE TERRAIN FOUND (and no custom bounds).");
            return;
        }

        _cachedTerrain = t2;

        Vector3 terrainPos = t2.transform.position;
        Vector3 terrainSize = t2.terrainData.size;

        minX = terrainPos.x;
        maxX = terrainPos.x + terrainSize.x;
        minZ = terrainPos.z;
        maxZ = terrainPos.z + terrainSize.z;

        hasBounds = true;

        if (debugLogs)
        {
            Debug.Log(
                $"[PlayerMapIcon] Using TERRAIN bounds: {t2.name}\n" +
                $"  Terrain pos:  {terrainPos}\n" +
                $"  Terrain size: {terrainSize}\n" +
                $"  Bounds X: {minX} -> {maxX}, Z: {minZ} -> {maxZ}"
            );
        }
    }

    private void Update()
    {
        if (!hasBounds) return;
        if (player == null || playerIcon == null || mapRect == null) return;

        float w = mapRect.rect.width;
        float h = mapRect.rect.height;

        if (w <= 0.01f || h <= 0.01f) return;

        float worldX = player.position.x;
        float worldZ = player.position.z;

        if (swapXZ)
            (worldX, worldZ) = (worldZ, worldX);

        float nx = Mathf.InverseLerp(minX, maxX, worldX);
        float ny = Mathf.InverseLerp(minZ, maxZ, worldZ);

        nx = Mathf.Clamp01(nx);
        ny = Mathf.Clamp01(ny);

        if (invertX) nx = 1f - nx;
        if (invertY) ny = 1f - ny;

        nx = Mathf.Clamp01(nx * normalizedScale.x + normalizedOffset.x);
        ny = Mathf.Clamp01(ny * normalizedScale.y + normalizedOffset.y);

        Vector2 p = new Vector2((nx - 0.5f) * w, (ny - 0.5f) * h);

        if (Mathf.Abs(mapRotationDegrees) > 0.01f)
        {
            float rad = mapRotationDegrees * Mathf.Deg2Rad;
            float cos = Mathf.Cos(rad);
            float sin = Mathf.Sin(rad);
            p = new Vector2(p.x * cos - p.y * sin, p.x * sin + p.y * cos);
        }

        playerIcon.anchoredPosition = p;

        if (debugLogs && Time.unscaledTime >= _nextDebugTime)
        {
            _nextDebugTime = Time.unscaledTime + Mathf.Max(0.05f, debugEverySeconds);

            string boundsSrc = useCustomWorldBounds && worldBottomLeft != null && worldTopRight != null
                ? "CUSTOM"
                : (_cachedTerrain != null ? $"TERRAIN({_cachedTerrain.name})" : "UNKNOWN");

            Debug.Log(
                $"[PlayerMapIcon] src={boundsSrc}\n" +
                $"  player world: {player.position}\n" +
                $"  worldX/worldZ used: ({worldX:F2}, {worldZ:F2})\n" +
                $"  bounds X: {minX:F2}->{maxX:F2} Z: {minZ:F2}->{maxZ:F2}\n" +
                $"  nx/ny: ({nx:F3}, {ny:F3})  map(w,h)=({w:F1},{h:F1})\n" +
                $"  icon anchoredPosition: {playerIcon.anchoredPosition}\n" +
                $"  settings: swapXZ={swapXZ} invertX={invertX} invertY={invertY} rot={mapRotationDegrees}  " +
                $"scale={normalizedScale} offset={normalizedOffset}"
            );
        }
    }
}
