using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class Tile : MonoBehaviour, IDropHandler
{
    [SerializeField] private Color baseColor, uiColor; //offsetColor
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    
    public Vector2Int gridPosition;
    private GridManager _gridData;

    public void Init(Vector2Int pos, GridManager data)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        gridPosition = pos;
        _gridData = data;
    }

    public void OnDrop(PointerEventData eventData)
    {
        
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
