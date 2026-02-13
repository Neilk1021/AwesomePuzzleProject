using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData : MonoBehaviour
{
    public int width = 7;
    public int height = 6;

    private RobotComponent[,] _grid;

    public void Initialize()
    {
        _grid = new RobotComponent[width, height];
    }

    public bool IsInside(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
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
        _grid = new RobotComponent[width, height];
    }

    public bool CheckAllValidLocations()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
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

}
