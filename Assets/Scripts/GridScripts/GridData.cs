using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData : MonoBehaviour
{
    public int height = 6;
    public int width = 7;

    private RobotComponent[,] _grid;
    

    public void Initialize()
    {
        _grid = new RobotComponent[height, width];
    }

    public bool IsInside(int x, int y)
    {
        return x >= 0 && x < height && y >= 0 && y < width;
    }

    public void Add(int x, int y, RobotComponent component)
    {
        if (!IsInside(x, y)) return;
        _grid[x, y] = component;
    }

    public void Remove(int x, int y)
    {
        if (!IsInside(x, y)) return;
        _grid[x, y] = null;
    }

    public void Clear()
    {
        _grid = new RobotComponent[height, width];
    }

    public bool CheckAllValidLocations()
    {
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                // here check if robot component is connected to something
            }
        }

        return true;
    }

    public RobotComponent Get(int x, int y)
    {
        return _grid[x, y];
    }

    public bool CoreCheck(Vector2Int pos)
    {
        return (pos.x == height - 1 && pos.y == width - 1);
    }
}
