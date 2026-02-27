using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
        int coreCount = 0;
        int componentCount = 0;
        RobotComponentData core = null;
        var corePosition = (-1, -1);

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                RobotComponentData component = _grid[row, col];

                if (component == null)
                    continue;
                if (component.IsCore)
                {
                    coreCount++;
                    componentCount++;
                    core = component;
                    corePosition = (row, col);
                    continue;
                }
                else
                {
                    componentCount++;
                }
            }

        }


        if (coreCount != 1)
        {
            print("more than 1 core: coreCount=" + coreCount);
            return false;
        }

        var checkQueue = new Queue<(int x, int y)>();
        var checkedPos = new List<(int x, int y)>();
        int checkedComponentCount = 0;

        checkQueue.Enqueue(corePosition);
        checkedPos.Add(corePosition);
        do
        {
            var currPos = checkQueue.Dequeue();
            RobotComponentData currComp = _grid[currPos.x, currPos.y];
            checkedComponentCount++;
            print("checking " + currComp.Type + " at (" + currPos.x + ", " + currPos.y + ")");
            var neighbors = GetNeighborPositions(currPos.x, currPos.y);
            foreach (var pos in neighbors)
            {
                if (!checkedPos.Contains(pos))
                {
                    checkedPos.Add(pos);
                    if (HasComponentAt(pos.x, pos.y))
                        checkQueue.Enqueue((pos.x, pos.y));
                }
            }
            if (checkedComponentCount > 500)
            {
                print("infinite loop YAY");
                return false;
            }
        } while (checkQueue.Count > 0);

        if (checkedComponentCount != componentCount)
        {
            print("checkedComponentCount != componentCount: "+checkedComponentCount+" != "+componentCount);
            return false;
        }

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {

                RobotComponentData component = _grid[row, col];
                if (component == null)
                    continue;
                if (component.IsCore)
                    continue;
                

                bool hasValidConnection = false;

                // Top
                if (!hasValidConnection && component.canConnectFromTop && HasComponentAt(row - 1, col))
                {
                    var neighbor = _grid[row - 1, col];
                    if (neighbor.canConnectFromBottom)
                    {
                        hasValidConnection = true;
                    }
                }

                // Left
                if (!hasValidConnection && component.canConnectFromLeft && HasComponentAt(row, col - 1))
                {
                    var neighbor = _grid[row, col - 1];
                    if (neighbor.canConnectFromRight)
                    {
                        hasValidConnection = true;
                    }
                }

                // Bottom
                if (!hasValidConnection && component.canConnectFromBottom && HasComponentAt(row + 1, col))
                {
                    var neighbor = _grid[row + 1, col];
                    if (neighbor.canConnectFromTop)
                    {
                        hasValidConnection = true;
                    }
                }

                // Right
                if (!hasValidConnection && component.canConnectFromRight && HasComponentAt(row, col + 1))
                {
                    var neighbor = _grid[row, col + 1];
                    if (neighbor.canConnectFromLeft)
                    {
                        hasValidConnection = true;
                    }
                }

                if (!hasValidConnection)
                {
                    print("invalid connection on " + component.Type + " at (" + row + ", " + col + ")");
                    return false;
                }
            }
        }



        return true;
    }

    private List<(int x, int y)> GetNeighborPositions(int x, int y)
    {
        var neighbors = new List<(int row, int col)>();

        int[] rowOffsets = { -1, 1, 0, 0 };
        int[] colOffsets = { 0, 0, -1, 1 };

        for (int i = 0; i < 4; i++)
        {
            int neighborRow = x + rowOffsets[i];
            int neighborCol = y + colOffsets[i];

            neighbors.Add((neighborRow, neighborCol));
        }

        return neighbors;
    }
    public void PrintValidate()
    {
        Debug.Log($"Validate Grid Data: {ValidateBot()}");
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




