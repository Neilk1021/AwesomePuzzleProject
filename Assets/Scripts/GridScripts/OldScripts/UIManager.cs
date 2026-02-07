using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class UIManager : MonoBehaviour
{
    [SerializeField] private int width = 5, height = 1;
    
    [SerializeField] private TileUI1 tilePrefab;

    [SerializeField] private Transform sceneCamera;
    
    void Start()
    {
        GenerateUI();
    }
    
    void GenerateUI()
    {
        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x - .5f, y - 2f), Quaternion.identity);
                spawnedTile.name = "Tile_" + x + "_" + y;
                spawnedTile.Init();
                
            } 
        }
    }
    
}
