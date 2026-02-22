using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class Tile : MonoBehaviour
{
    
    [SerializeField] private Coroutine _blinkcoroutine;
    [SerializeField] private Color baseColor, uiColor; //offsetColor
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;

    public Vector2Int gridPosition;
    public Vector2Int palettePosition;
    
    [SerializeField] private PaletteManager _paletteManager;
    [SerializeField] private GridManager _gridManager;

    private bool _isGridTile;
    private bool _isPaletteTile;
    
    public void InitializeGrid(Vector2Int pos, GridManager manager)
    {
        gridPosition = pos;
        _gridManager = manager;
        _isGridTile = true;
    }

    public void InitializePalette(Vector2Int pos, PaletteManager manager)
    {
        palettePosition = pos;
        _paletteManager = manager;
        _isPaletteTile = true;
    }

    void OnMouseDown()
    {
        if (_isGridTile)
        {
            _gridManager.HandleGridClick(gridPosition);
        }

        if (_isPaletteTile)
        {
            _paletteManager.SelectTile(this);
            return;
        }
        

    }

    public void SetIcon(Sprite sprite)
    {
        if (spriteRenderer == null) return;
        spriteRenderer.sprite = sprite;
    }
    
    void SetAlpha(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;  // Only change the alpha (transparency)
        spriteRenderer.color = color;
    }
    public void StartBlinkTile()
    {
        if (_blinkcoroutine != null)
        {
            StopCoroutine(_blinkcoroutine);
        }

        _blinkcoroutine = StartCoroutine(BlinkTile());
    }

    public void StopBlinkTile()
    {
        if (_blinkcoroutine != null)
        {
            StopCoroutine(_blinkcoroutine);
            _blinkcoroutine = null;
        } 
        SetAlpha(1.0f);
    }

    public IEnumerator BlinkTile()
    {
        while (true)
        {
            SetAlpha(0.5f);
            yield return new WaitForSeconds(0.3f);
            SetAlpha(1.0f);
            yield return new WaitForSeconds(0.3f);
        }
    }

}
