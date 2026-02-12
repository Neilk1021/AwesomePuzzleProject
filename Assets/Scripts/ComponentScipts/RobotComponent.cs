using Unity.Collections;
using UnityEngine;
using System.Collections.Generic;

public abstract class RobotComponent : MonoBehaviour
{
    public Vector2Int GridPosition {get; set;}
    protected GridData Data;

    private List<string> _validLocation = new List<string>();

    public virtual void Initialize(Vector2Int pos, GridData d, List<string> location)
    {
        GridPosition = pos;
        Data = d;
        _validLocation = location;
        
        // need builder
    }

    public void SetLocation(Vector2Int pos)
    {
        GridPosition.Set(pos.x, pos.y);
    }
    
    public virtual bool ValidConnection(string location)
    {
        return _validLocation.Contains(location);
    }

    public virtual void MoveTo(int x, int y)
    {
        // grid builder move component to new location
    }

    public virtual void DestroySelf()
    {
        // remove itself from Data
        // delete itself in grid builder
    }

    private void OnMouseDown()
    {
        Debug.Log($"Clicked {name} at {GridPosition}");
    }
}