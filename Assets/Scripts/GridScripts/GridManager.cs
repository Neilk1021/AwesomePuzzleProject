using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GridData _gridData;
    [SerializeField] private GridBuilder _gridBuilder;
    private RobotCore _robotCore;
    public Tile currTile;

    private void Awake()
    {
        _gridData.Initialize();
        _gridBuilder.Build(_gridData);
        _robotCore = gameObject.AddComponent<RobotCore>();
        _gridData.Add(3, 1, _robotCore);
    }
    
    public bool CoreLocationSelected()
    {
        if (currTile != null && currTile._paletteData != null)
        {
            return currTile._gridData.CoreCheck(currTile.gridPosition);
        }
        return false;
    }


}

