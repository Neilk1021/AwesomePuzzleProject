using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteManager : MonoBehaviour
{
    [SerializeField] private PaletteData _paletteData;
    [SerializeField] private PaletteBuilder _paletteBuilder;
    [SerializeField] private GameObject trashIcon;
    
    public Tile currTile;
    
    private void Awake()
    {
        _paletteBuilder.Build(_paletteData);
    }
    
    public void SelectTile(Tile tile)
    {
        if (currTile != null)
        {
            currTile.StopBlinkTile();
        }

        if (currTile == tile)
        {
            currTile.StopBlinkTile();
            currTile = null;
            return;
        }
        currTile = tile;
        tile.StartBlinkTile();

        Debug.Log("Selected Tile: " + tile.palettePosition);
    }

    public Tile GetSelectedTile()
    {
        return currTile;
    }

    public void ClearTileSelection()
    {
        if (currTile != null)
        {
            Debug.Log("Selected tile cleared: " + currTile.palettePosition);
            currTile.StopBlinkTile();
            currTile = null;
        }
    }

    public Sprite GetSelectedItemSprite()
    {
        if (currTile != null && currTile._paletteData != null)
        {
            return currTile._paletteData.GetSpriteForPosition(currTile.palettePosition);
        }
        return null;
    }

    public bool TrashCanSelected()
    {
        if (currTile != null && currTile._paletteData != null)
        {
            return currTile._paletteData.TrashCanCheck(currTile.palettePosition);
        }
        return false;
    }
}
