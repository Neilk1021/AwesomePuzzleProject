using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO Rename this to something data related rather than manager as thats confusing
//TODO derive not from scriptable object, either monobehaviour if you want the start and update loop or a generic class if you dont 
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
