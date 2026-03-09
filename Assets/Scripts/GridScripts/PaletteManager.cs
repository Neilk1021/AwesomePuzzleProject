using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteManager : MonoBehaviour
{
    [SerializeField] private PaletteData _paletteData;
    [SerializeField] private PaletteBuilder _paletteBuilder;
    
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

    }

    public Tile GetSelectedTile()
    {
        return currTile;
    }

    public void ClearTileSelection()
    {
        if (currTile != null)
        {
            currTile.StopBlinkTile();
            currTile = null;
        }
    }

    public RobotComponentType GetSelectedComponentType()
    {
        if (currTile == null)
            return RobotComponentType.None;
        return _paletteData.GetTypeForPosition(currTile.palettePosition);
    }

    public Sprite GetSelectedSprite()
    {
        if (currTile == null)
            return null;
        return _paletteData.GetSpriteForPosition(currTile.palettePosition);
    }

    public bool TrashCanSelected()
    {
        if (currTile == null) return false;
        
        return _paletteData.TrashCanCheck(currTile.palettePosition);
    }
}
