using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, uiColor; //offsetColor
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    
    public Vector2Int gridPosition;
    private GridData _gridData;

    public Vector2Int palettePosition;
    private PaletteData _paletteData;
    [SerializeField] private SpriteRenderer itemsRenderer;

    //Dependency injection is good!
    public void Initialize(Vector2Int pos, GridData data)
    {
        gridPosition = pos;
        _gridData = data;
    }
    
    public void InitializePalette(Vector2Int pos, PaletteData data)
    {
        palettePosition = pos;
        _paletteData = data;
        
        // Get single sprite
        Sprite sprite = data.GetSpriteForPosition(pos);
        
        if (itemsRenderer != null && sprite != null)
        {
            itemsRenderer.sprite = sprite;
        }
    }
    
    void OnMouseDown()
    {
        Debug.Log("meow meow");
        Debug.Log($"Clicked tile: {gridPosition}");
        SetAlpha(0.5f);
    }
    
    private void OnMouseUp()
    {
        //highlight.SetActive(false);
        SetAlpha(1.0f);
    }
    
    void SetAlpha(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;  // Only change the alpha (transparency)
        spriteRenderer.color = color;
    }
}
