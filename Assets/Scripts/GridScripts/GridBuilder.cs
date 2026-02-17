using UnityEngine;

public class GridBuilder : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform gridParent;
    [SerializeField] private PaletteManager paletteManager;

    [SerializeField] private Sprite coreSprite;

    public Tile[,] Tiles;
    
    public void Build(GridData gridData)
    {
        Tiles = new Tile[gridData.width, gridData.height];
        
        for (int x = 0; x < gridData.width; x++)
        {
            for (int y = 0; y < gridData.height; y++)
            {
                Vector3 offset = new Vector3(-gridData.width / 2f + 0.5f, -gridData.height / 2f + 0.5f, 0);
                Vector3 position = new Vector3(x, y, 0) + offset;
                
                GameObject tileObj = Instantiate(tilePrefab, position, Quaternion.identity, gridParent);

                if (gridParent != null)
                {
                    tileObj.transform.SetParent(gridParent);
                }
                Tile map = tileObj.GetComponent<Tile>();
                Tiles[x, y] = map;
                
                Tile tile = tileObj.GetComponent<Tile>();
                tile.Initialize(new Vector2Int(x, y), gridData, paletteManager);
            }
        }
        Tile centerTile = Tiles[gridData.width / 2, gridData.height / 2];
        centerTile.itemsRenderer.sprite = coreSprite;
        //cant move??
    }
    
}