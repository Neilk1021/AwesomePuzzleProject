using Unity.Collections;
using UnityEngine;
using System.Collections.Generic;

public abstract class RobotComponent : MonoBehaviour
{
    public Vector2Int GridPosition { get; set; }
    protected GridData Data;

    public int Rotation { get; private set; } = 0; // 0, 90, 180, 270

    public bool canConnectFromLeft { get; protected set; } = false;
    public bool canConnectFromRight { get; protected set; } = false;
    public bool canConnectFromTop { get; protected set; } = false;
    public bool canConnectFromBottom { get; protected set; } = false;

    protected bool baseLeft;
    protected bool baseRight;
    protected bool baseTop;
    protected bool baseBottom;
    
    public virtual void Initialize(Vector2Int pos, int rotation = 0)
    {
        GridPosition = pos;
        SetRotation(rotation);
    }

    public void SetRotation(int rotation)
    {
        Rotation = rotation % 360;
        ApplyRotation();
        transform.rotation = Quaternion.Euler(0f, 0f, Rotation);
    }

    public void ApplyRotation()
    {
        canConnectFromLeft = baseLeft;
        canConnectFromRight = baseRight;
        canConnectFromTop = baseTop;
        canConnectFromBottom = baseBottom;

        int steps = Rotation / 90;

        for (int i = 0; i < steps; i++)
        {
            RotateClockwise();
        }
    }

    void RotateClockwise()
    {
        bool temp = canConnectFromRight;
        canConnectFromTop = canConnectFromLeft;
        canConnectFromLeft = canConnectFromBottom;
        canConnectFromBottom = canConnectFromRight;
        canConnectFromRight = temp;

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