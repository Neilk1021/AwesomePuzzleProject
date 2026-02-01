using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, uiColor; //offsetColor
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;

    public void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
