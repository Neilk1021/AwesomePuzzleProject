using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GridData _gridData;
    [SerializeField] private GridBuilder _gridBuilder;
    [SerializeField] private PaletteManager _paletteManager;
    [SerializeField] private PlacementPreview _placementPreview;
    
    private RobotCore _robotCore;
    public Tile currTile;
    

    private void Awake()
    {
        _gridData.Initialize();
        _gridBuilder.Build(_gridData, this);
        PlaceCore();


    }

    void PlaceCore()
    {
        var core = new RobotComponentData(new Vector2Int(3, 1), 0, RobotComponentType.Core );
        _gridData.Add(core);
        _gridBuilder.Rebuild();
    }

    /// <summary>
    /// Called by grid tile when clicked
    /// </summary>
    public void HandleGridClick(Vector2Int pos)
    {
        if (_paletteManager.TrashCanSelected())
        {
            RemoveComponent(pos);
            return;
        }

        RobotComponentType type = _paletteManager.GetSelectedComponentType();

        if (type == RobotComponentType.None)
        {
            return;
        }

        PlaceComponent(type, pos);
    }

    private void PlaceComponent(RobotComponentType type, Vector2Int pos)
    {
        int rotation = _placementPreview.GetCurrentRotation();
        
        var newData = new RobotComponentData(pos, rotation, type);
        
        _gridData.Add(newData);
        _gridBuilder.Rebuild();

        _paletteManager.ClearTileSelection();
    }

    private void RemoveComponent(Vector2Int pos)
    {
        var data = _gridData.Get(pos.x, pos.y);
        if (data == null)
        {
            return;
        }

        // if (data.IsCore)
        // {
        //     return; 
        // }
        
        _gridData.Remove(pos.x, pos.y);
        _gridBuilder.Rebuild();
        
        _paletteManager.ClearTileSelection();
    }

}

