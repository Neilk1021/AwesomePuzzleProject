using UnityEngine;

public class GridBuilder : MonoBehaviour
{
    [SerializeField] GridData gridData;
    [SerializeField] private Tile tilePrefab;
    
    [SerializeField] private Transform sceneCamera;
    
    void Start()
    {
        GenerateGrid();
    }
    
    void GenerateGrid()
    {
        gridData.ClearGrid();
        
        for (int x = 0; x < gridData.width; x++){
            for (int y = 0; y < gridData.height; y++){
                Vector3 pos = new Vector3(x * gridData.tileSize, y * gridData.tileSize, 0);
                Tile tile = Instantiate(tilePrefab, pos, Quaternion.identity, transform);
                tile.Init(new Vector2Int(x, y), gridData);
            }
        }
        
        sceneCamera.transform.position = new Vector3((float)gridData.width/2 -0.5f, (float)gridData.height/2 -0.5f, -10);    
    }
}