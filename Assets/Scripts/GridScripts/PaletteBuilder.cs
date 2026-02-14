using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PaletteBuilder : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform paletteParent;
    
    public void Build(PaletteData paletteData)
    {
        for (int x = 0; x < paletteData.width; x++)
        {
            for (int y = 0; y < paletteData.height; y++)
            {
                Vector3 offset = new Vector3(-paletteData.width / 2f + 0.5f, -paletteData.height / 2f + 0.5f, 0);
                Vector3 position = new Vector3(x, y - 3.5f, 0) + offset;
                
                GameObject tileObj = Instantiate(tilePrefab, position, Quaternion.identity, paletteParent);

                if (paletteParent != null)
                {
                    tileObj.transform.SetParent(paletteParent);
                }
                
                Tile tile = tileObj.GetComponent<Tile>();
                tile.InitializePalette(new Vector2Int(x,y), paletteData);
            }
        }
    }
    
    
}


