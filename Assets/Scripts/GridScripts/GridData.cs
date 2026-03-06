using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

/// <summary>
/// Holds grid data in a 2D array
/// NO KNOWLEDGE OF UI
/// </summary>
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
        // Find Core
        var corePosition = FindCore();
        if (corePosition == null)
        {
            Debug.Log("No core found.");
            return false;
        }
        
        // Check if every component is reachable from Core
        int totalComponents = CountComponents();
        int reached = BFS(corePosition.Value);

        if (reached != totalComponents)
        {
            Debug.Log("All components CANNOT be reached from Core");
            return false;
        }
        
        // Every component has at least one valid connection
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                var component = _grid[row, col];
                if (component == null || component.IsCore) continue;

                if (!HasValidConnection(row, col))
                {
                    Debug.Log($"Invalid connection: {component.Type} at ({row}, {col})");
                    return false;
                }
            }
        }
        
        return true;
    }
    
    ///// HELPER FUNCTIONS /////

    /// Returns core position if there is only ONE CORE
    /// Returns null if coreCount != 1
    private (int x, int y)? FindCore()
    {
        int coreCount = 0;
        (int x, int y)? corePos = null;

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (_grid[row, col] != null && _grid[row, col].IsCore)
                {
                    corePos = (col, row);
                    coreCount++;
                }
            }
        }
        return coreCount == 1 ? corePos : null;
    }
    
    /// Returns number of components
    private int CountComponents()
    {
        int count = 0;
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (_grid[row, col] != null) count++;
            }
        }
        
        return count;
    }
    
    /// Queue to check all component's neighbors
    /// HashSet to store visited components
    private int BFS((int x, int y) start)
    {
        var queue = new Queue<(int x, int y)>();
        var visited = new HashSet<(int x, int y)>();
        
        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            foreach (var neighbor in GetNeighborPositions(x, y))
            {
                if (!visited.Contains(neighbor) && HasComponentAt(neighbor.x, neighbor.y))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
        
        return visited.Count;
    }
    
    /// Uses a tuple for directions
    /// Checks if a component at row, col has at least one valid connection
    private bool HasValidConnection(int row, int col)
    {
        var c = _grid[row, col];

        var checks =
            new (int rowOffset, int colOffset, bool canConnect, System.Func<RobotComponentData, bool> neighborMustHave)
                []
                {
                    (-1, 0, c.canConnectFromTop, n => n.canConnectFromBottom),
                    (0, -1, c.canConnectFromLeft, n => n.canConnectFromRight),
                    (1, 0, c.canConnectFromBottom, n => n.canConnectFromTop),
                    (0, 1, c.canConnectFromRight, n => n.canConnectFromLeft),
                };

        foreach (var (rowOffset, colOffset, canConnect, neighborMustHave) in checks)
        {
            if (!canConnect) continue;
            var neighbor = HasComponentAt(row + rowOffset, col + colOffset) ? _grid[row + rowOffset, col + colOffset] : null;
            if (neighbor != null && neighborMustHave(neighbor)) return true;
        }

        return false;
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
        if (x < 0 || y < 0 || x >= height || y >= width)
            return false;
        else
            return _grid[x, y] != null;
    }

    public RobotComponentData Get(int x, int y)
    {
        return _grid[x, y];
    }
    
    public bool IsInside(int row, int col)
    {
        return row >= 0 && row < height && col >= 0 && col < width;
    }

}




