using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData : MonoBehaviour
{
    public int height = 6;
    public int width = 7;

    private RobotComponentData[,] _grid;
    

    public void Initialize()
    {
        _grid = new RobotComponentData[height, width];
    }
    
    public void Add(RobotComponentData component)
    {
        if (!IsInside(component.GridPosition.x, component.GridPosition.y)) return;
        _grid[component.GridPosition.x, component.GridPosition.y] = component;
    }

    public void Remove(int row, int col)
    {
        if (!IsInside(row, col)) return;
        _grid[row, col] = null;
    }

    public bool ValidateBot()
    {
        for (int row= 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                RobotComponentData component = _grid[row, col];
                if (component == null || component is RobotCore)
                    continue;
                if (!(
                    (component.canConnectFromLeft && HasComponentAt(row, col-1)) || 
                    (component.canConnectFromRight && HasComponentAt(row, col+1)) ||
                    (component.canConnectFromTop && HasComponentAt(row-1, col)) ||
                    (component.canConnectFromBottom && HasComponentAt(row+1, col))
                    ))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool HasComponentAt(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= height)
            return false;
        else
            return _grid[x, y] != null;
    }

    public RobotComponentData Get(int x, int y)
    {
        return _grid[x, y];
    }

    public bool CoreCheck(Vector2Int pos)
    {
        return (pos.x == height - 1 && pos.y == width - 1);
    }
    
    public bool IsInside(int row, int col)
    {
        return row >= 0 && row < height && col >= 0 && col < width;
    }

}




