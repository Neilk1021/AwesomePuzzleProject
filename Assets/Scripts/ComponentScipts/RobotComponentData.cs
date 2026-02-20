using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotComponentData
{
    public Vector2Int GridPosition;
    public int Rotation; // 0,90,180,270

    public bool canConnectFromLeft;
    public bool canConnectFromRight;
    public bool canConnectFromTop;
    public bool canConnectFromBottom;

    public GameObject prefab;

    public RobotComponentData(
        Vector2Int gridPosition,
        int rotation,
        GameObject prefab,
        bool left,
        bool right,
        bool top,
        bool bottom)
    {
        GridPosition = gridPosition;
        Rotation = rotation;
        this.prefab = prefab;
        canConnectFromLeft = left;
        canConnectFromRight = right;
        canConnectFromTop = top;
        canConnectFromBottom = bottom;
    }
}
