using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : ScriptableObject
{
    public int width = 6;
    public int height = 6;
    public float tileSize = 1f;
    
    public Dictionary<Vector2Int, RobotComponent> PlacedComponent = new Dictionary<Vector2Int, RobotComponent>();

    public void ClearGrid()
    {
        PlacedComponent.Clear();
    }

    public bool IsOccupied(Vector2Int pos)
    {
        return PlacedComponent.ContainsKey(pos);
    }

    public void PlaceComponent(Vector2Int pos, RobotComponent component)
    {
        PlacedComponent[pos] = component;
    }
    
    public void RemoveComponent(Vector2Int pos)
    {
        if (PlacedComponent.ContainsKey(pos))
            PlacedComponent.Remove(pos);
    }
}
