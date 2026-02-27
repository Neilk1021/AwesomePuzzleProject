using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotComponentData
{
    public Vector2Int GridPosition;
    public int Rotation; // 0,90,180,270
    public RobotComponentType Type;

    public bool canConnectFromLeft;
    public bool canConnectFromRight;
    public bool canConnectFromTop;
    public bool canConnectFromBottom;

    public bool IsCore => Type == RobotComponentType.Core;

    public RobotComponentData(
        Vector2Int gridPosition,
        int rotation,
        RobotComponentType type)
    {
        GridPosition = gridPosition;
        Rotation = rotation;
        Type = type;
        
        SetBaseConnections(type);
        ApplyRotation();
    }
    
    void SetBaseConnections(RobotComponentType type)
    {
        switch (type)
        {
            case RobotComponentType.Core:
                canConnectFromLeft = true;
                canConnectFromRight = true;
                canConnectFromTop = true;
                canConnectFromBottom = true;
                break;

            case RobotComponentType.Fan:
                canConnectFromRight = true;
                break;

            case RobotComponentType.Wheel:
                canConnectFromTop = true;
                break;
            
            case RobotComponentType.Magnet:
                canConnectFromBottom = true;
                break;

            case RobotComponentType.BuildingBlock:
                canConnectFromLeft = true;
                canConnectFromRight = true;
                canConnectFromTop = true;
                canConnectFromBottom = true;
                break;

        }
    }

    public void ApplyRotation()
    {
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
}
