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

    public bool IsInside(int row, int col)
    {
        return row >= 0 && row < height && col >= 0 && col < width;
    }

    public void Add(int row, int col, RobotComponent component)
    {
        if (!IsInside(row, col)) return;
        _grid[row, col] = component;
    }

    public void Remove(int row, int col)
    {
        if (!IsInside(row, col)) return;
        _grid[row, col] = null;
    }

    public void Clear()
    {
        _grid = new RobotComponent[height, width];
    }

    public bool ValidateBot()
    {
        for (int row= 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                RobotComponent component = _grid[row, col];
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

    
    
    // "unittest" cuz im stupid and lazy
    public void TestValidation()
    {
        Initialize();
        GameObject robotCore = new GameObject("Robot Core");
        RobotComponent coreScript = robotCore.AddComponent<RobotCore>();
        coreScript.Initialize(new Vector2Int(3, 3));
        Add(3, 3, coreScript);
        Debug.Assert(ValidateBot() == true);
        GameObject wheel = new GameObject("Wheel");
        RobotComponent wheelScript = wheel.AddComponent<Wheel>();
        wheelScript.Initialize(new Vector2Int(4, 3));
        Add(4, 3, wheelScript);
        Debug.Assert(ValidateBot() == true);
        GameObject wheel2 = new GameObject("Invalid Wheel");
        RobotComponent wheel2Script = wheel2.AddComponent<Wheel>();
        Add(5, 5, wheel2Script);
        Debug.Assert(ValidateBot() == false);

        for (int x = 0; x < height; x++)
        {
            string row = "";
            for (int y = 0; y < width; y++)
            {
                if (_grid[x, y] == null)
                    row += "null, ";
                row += _grid[x, y] + ", ";

            }
            print(row);
        }
    }

    private bool HasComponentAt(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= height)
            return false;
        else
            return _grid[x, y] != null;
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
