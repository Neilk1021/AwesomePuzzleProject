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

    
    //Dependency injection is good!
    public void Initialize(Vector2Int pos, GridData data)
    {
        gridPosition = pos;
        _gridData = data;
    }

    void OnMouseDown()
    {
        Debug.Log("meow meow");
        Debug.Log($"Clicked tile: {gridPosition}");
    }
    
    private void OnMouseEnter()
    {
        //highlight.SetActive(true);
        SetAlpha(0.5f);
    }
    
    private void OnMouseExit()
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
