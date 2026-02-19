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
    public GridData _gridData;
    public Vector2Int palettePosition;
    public PaletteData _paletteData;
    public SpriteRenderer itemsRenderer;
    [SerializeField] private PaletteManager _paletteManager;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private PlacementPreview _placementPreview;
    
    public void Initialize(Vector2Int pos, GridData data, PaletteManager manager, PlacementPreview placementPreview)
    {
        gridPosition = pos;
        _gridData = data;
        _paletteManager = manager;
        _placementPreview = placementPreview;
    }

    public void InitializePalette(Vector2Int pos, PaletteData data, PaletteManager manager)
    {
        palettePosition = pos;
        _paletteData = data;
        _paletteManager = manager;

        // Get single sprite
        Sprite sprite = data.GetSpriteForPosition(pos);

        if (itemsRenderer != null && sprite != null)
        {
            itemsRenderer.sprite = sprite;
        }
    }

    void OnMouseDown()
    {
        if (_paletteData != null)
        {
            Debug.Log($"Clicked palette tile at: {palettePosition}");
            Sprite selectedSprite = _paletteData.GetSpriteForPosition(palettePosition);
            _paletteManager.SelectTile(this);
            //tell manager
        }
        else if (_gridData != null)
        {
            Debug.Log($"Clicked grid tile at: {gridPosition}");
            // ask manager and update
            if (_paletteManager != null)
            {
                //trash can
                if (_paletteManager.TrashCanSelected())
                {
                    Debug.Log($"Trash can selected");
                    if (itemsRenderer != null)
                    {
                        itemsRenderer.sprite = null;
                    }

                    _gridData.Remove(gridPosition.x,  gridPosition.y);

                    _paletteManager.ClearTileSelection();
                    
                    return;
                }
                
                /*if (_gridManager.CoreLocationSelected())
                {
                    Debug.Log($"Core selected");

                    _paletteManager.ClearTileSelection();
                    
                    return;
                }*/
                
                Tile selectedTile = _paletteManager.GetSelectedTile();
                if (selectedTile != null)
                {
                    //Sprite selectedSprite = _paletteData.GetSpriteForPosition(selectedTile.palettePosition);
                    Sprite selectedSprite = _paletteManager.GetSelectedItemSprite();
                    if (itemsRenderer != null && selectedSprite != null)
                    {
                        itemsRenderer.sprite = selectedSprite;
                        itemsRenderer.transform.rotation =
                            Quaternion.Euler(0f, 0f, _placementPreview.GetCurrentRotation());
                    }
                    _paletteManager.ClearTileSelection();
                }
                else
                {
                    Debug.Log("No palette tile selected!");
                }
            }
        }
        else
        {
            Debug.LogWarning("Tile not initialized!");
        }
        

    }

    private void OnMouseUp()
    {
        
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
