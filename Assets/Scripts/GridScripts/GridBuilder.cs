using UnityEngine;
using System.Collections.Generic;

public class GridBuilder : MonoBehaviour
{
    [Header("Tiles")]
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform gridParent;
    
    [Header("Components")]
    [SerializeField] private Transform componentParent;
    [SerializeField] private ComponentPrefabLibrary prefabLibrary;
    
    private Tile[,] Tiles;
    private Dictionary<Vector2Int, GameObject> _spawnedComponents = new Dictionary<Vector2Int, GameObject>();

    private GridData _gridData;
    
    // build grid tiles
    public void Build(GridData gridData, GridManager gridManager)
    {
        _gridData = gridData;
        Tiles = new Tile[gridData.height, gridData.width];
        
        for (int x = 0; x < gridData.height; x++)
        {
            for (int y = 0; y < gridData.width; y++)
            {
                Vector3 position =  GridToWorld(new Vector2Int(x, y), gridData.height, gridData.width);
                
                GameObject tileObj = Instantiate(tilePrefab, position, Quaternion.identity, gridParent);

                if (gridParent != null)
                {
                    tileObj.transform.SetParent(gridParent);
                }
                
                Tile tile = tileObj.GetComponent<Tile>();
                tile.InitializeGrid(new Vector2Int(x, y), gridManager);
                
                Tiles[x, y] = tile;
            }
        }
    }

    // rebuild visual components
    public void Rebuild()
    {
        ClearAllComponents();

        for (int row = 0; row < _gridData.height; row++)
        {
            for (int col = 0; col < _gridData.width; col++)
            {
                RobotComponentData data = _gridData.Get(row, col);
                if (data == null) continue;
                SpawnComponent(data);
            }
        }
    }

    private void SpawnComponent(RobotComponentData data)
    {
        GameObject prefab = prefabLibrary.GetPrefab(data.Type);

        if (prefab == null)
        {
            Debug.LogError($"Couldn't find prefab {data.Type}");
            return;
        }
        
        Vector3 position = GridToWorld(data.GridPosition, _gridData.height, _gridData.width);
        
        GameObject obj = Instantiate(prefab, position, Quaternion.Euler(0f, 0f, data.Rotation), componentParent);
        
        _spawnedComponents.Add(data.GridPosition, obj);
        
        
    }

    private void ClearAllComponents()
    {
        foreach (var comp in _spawnedComponents)
        {
            if(comp.Value != null)
                Destroy(comp.Value);
        }
        _spawnedComponents.Clear();
    }
    
    private Vector3 GridToWorld(Vector2Int gridPosition, int height, int width)
    {
        Vector3 offset = new Vector3(-width / 2f + 0.5f, -height / 2f + 0.5f, 0);
        return new Vector3(gridPosition.y, gridPosition.x, 0) + offset;
    }
    
    public GameObject BuildRobot(Transform robotParent = null)
    {
        RobotComponentData coreData = null;
    
    for (int row = 0; row < _gridData.height; row++)
    {
        for (int col = 0; col < _gridData.width; col++)
        {
            RobotComponentData data = _gridData.Get(row, col);
            if (data != null && data.IsCore)
            {
                coreData = data;
                break;
            }
        }
        if (coreData != null) break;
    }
    
    if (coreData == null)
    {
        Debug.LogError("No core found! Cannot build robot.");
        return null;
    }
    
    GameObject corePrefab = prefabLibrary.GetPrefab(coreData.Type);
    Vector3 coreWorldPos = GridToWorld(coreData.GridPosition, _gridData.height, _gridData.width);
    
    GameObject coreObj = Instantiate(
        corePrefab,
        coreWorldPos,
        Quaternion.Euler(0f, 0f, coreData.Rotation),
        robotParent
    );
    coreObj.name = "Core";
    
    for (int row = 0; row < _gridData.height; row++)
    {
        for (int col = 0; col < _gridData.width; col++)
        {
            RobotComponentData data = _gridData.Get(row, col);
            
            if (data == null || data.IsCore) continue; // Skip empty + core 
            
            GameObject prefab = prefabLibrary.GetPrefab(data.Type);
            if (prefab == null) continue;
            
            // Position relative to core
            Vector2Int offset = data.GridPosition - coreData.GridPosition;
            Vector3 localPos = new Vector3(offset.y, offset.x, 0); 
            
            GameObject obj = Instantiate(prefab, coreObj.transform); 
            obj.transform.localPosition = localPos;
            obj.transform.localRotation = Quaternion.Euler(0f, 0f, data.Rotation);
            obj.name = data.Type.ToString();
            
            Debug.Log($"Spawned {data.Type} at local pos {localPos}");
        }
    }
    
    Debug.Log("Robot built successfully!");
    return coreObj; // Return root for PlayerController etc. 
    }
}