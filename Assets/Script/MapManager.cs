using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    private static MapManager _instance;
    public static MapManager Instance { get { return _instance; } }

    public OverlayTile overlaytilePf;
    public GameObject overlayContainer;

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
                    Vector3 place = tileMap.CellToWorld(tileLocation);

                    if (tileMap.HasTile(tileLocation))
                    {
                        var OverlayTile = Instantiate(overlaytilePf, overlayContainer.transform);
                        var cellWorldPos = tileMap.GetCellCenterWorld(tileLocation);

                        OverlayTile.transform.position = new Vector3(cellWorldPos.x, cellWorldPos.y, cellWorldPos.z + 1);
                        OverlayTile.GetComponent<SpriteRenderer>().sortingOrder = tileMap.GetComponent<TilemapRenderer>().sortingOrder + 1;
                        OverlayTile.HideTile();
                    }
                }
            }
        }
    }
}
