using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    private static MapManager _instance;
    public static MapManager Instance { get { return _instance; } }

    [Header("Spawn Overlay")]
    public OverlayTile overlaytilePf;
    public GameObject overlayContainer;

    public Dictionary<Vector2Int, OverlayTile> map = new Dictionary<Vector2Int, OverlayTile>();

    [Header("Spawn Object")]
    public GameObject objectContainer;
    public List<GameObject> objectToSpawn = new List<GameObject>();

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        var tileMap = gameObject.GetComponentInChildren<Tilemap>();

        BoundsInt bounds = tileMap.cellBounds;

        for (int z = bounds.max.z; z >= bounds.min.z ; z--)
        {
            for (int x = bounds.min.x; x < bounds.max.x; x++)
            {
                for (int y = bounds.min.y; y < bounds.max.y; y++)
                {
                    var tileLocation = new Vector3Int(x, y, z);
                    var tileKey = new Vector2Int(x, y);
                    Vector3 place = tileMap.CellToWorld(tileLocation);

                    if (tileMap.HasTile(tileLocation) && !map.ContainsKey(tileKey))
                    {
                        var OverlayTile = Instantiate(overlaytilePf, overlayContainer.transform);
                        var cellWorldPos = tileMap.GetCellCenterWorld(tileLocation);

                        OverlayTile.transform.position = new Vector3(cellWorldPos.x, cellWorldPos.y, cellWorldPos.z + 1);
                        OverlayTile.GetComponent<SpriteRenderer>().sortingOrder = tileMap.GetComponent<TilemapRenderer>().sortingOrder + 1;
                        map.Add(tileKey, OverlayTile);
                        OverlayTile.HideTile();
                    }
                }
            }
        }

        for (int z = bounds.max.z; z >= bounds.min.z ; z--)
        {
            for (int x = bounds.min.x; x < bounds.max.x; x++)
            {
                for (int y = bounds.min.y; y < bounds.max.y; y++)
                {
                    var tileLocation = new Vector3Int(x, y, z);
                    var tileKey = new Vector2Int(x, y);
                    Vector3 place = tileMap.CellToWorld(tileLocation);

                    var Randomizer = Random.Range(0, 99);
                    if (tileMap.HasTile(tileLocation) && Randomizer > 80)
                    {
                        var obj = Instantiate(objectToSpawn[Random.Range(0, objectToSpawn.Count)], objectContainer.transform);
                        var cellWorldPos = tileMap.GetCellCenterWorld(tileLocation);

                        obj.transform.position = new Vector3(cellWorldPos.x, cellWorldPos.y, cellWorldPos.z + 1);
                        obj.GetComponent<SpriteRenderer>().sortingOrder = tileMap.GetComponent<TilemapRenderer>().sortingOrder + 1;
                    }
                }
            }
        }
    }
}
