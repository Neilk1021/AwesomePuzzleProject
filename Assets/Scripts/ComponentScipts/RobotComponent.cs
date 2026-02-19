using Unity.Collections;
using UnityEngine;
using System.Collections.Generic;

public abstract class RobotComponent : MonoBehaviour
{
    public Vector2Int GridPosition {get; set;}
    protected GridData Data;

    public bool canConnectFromLeft { get; protected set; } = false;
    public bool canConnectFromRight { get; protected set; } = false;
    public bool canConnectFromTop { get; protected set; } = false;
    public bool canConnectFromBottom { get; protected set; } = false;

    public virtual void Initialize(Vector2Int pos)
    {
        GridPosition = pos;
        // need builder
    }
    public void SetLocation(Vector2Int pos)
    {
        GridPosition.Set(pos.x, pos.y);
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