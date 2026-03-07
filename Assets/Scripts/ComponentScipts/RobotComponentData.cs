using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotComponentData
{
    public RobotComponentSO Definition;
    public Vector2Int GridPosition;
    public int Rotation; // 0,90,180,270

    public bool canConnectFromLeft;
    public bool canConnectFromRight;
    public bool canConnectFromTop;
    public bool canConnectFromBottom;

    public bool IsCore => Definition.type == RobotComponentType.Core;
    public RobotComponentType Type => Definition.type;

    public RobotComponentData(
        Vector2Int gridPosition,
        int rotation,
        RobotComponentSO definition)
    {
        GridPosition = gridPosition;
        Rotation = rotation;
        Definition = definition;
        
        canConnectFromLeft   = definition.canConnectFromLeft;
        canConnectFromRight  = definition.canConnectFromRight;
        canConnectFromTop    = definition.canConnectFromTop;
        canConnectFromBottom = definition.canConnectFromBottom;
        
        ApplyRotation();
    }

    void ApplyRotation()
    {
        int steps = Rotation / 90;

        for (int i = 0; i < steps; i++)
        {
            RotateCounterClockwise();
        }
    }

    void RotateCounterClockwise()
    {
        // bool temp = canConnectFromRight;
        // canConnectFromTop = canConnectFromLeft;
        // canConnectFromLeft = canConnectFromBottom;
        // canConnectFromBottom = canConnectFromRight;
        // canConnectFromRight = temp;
        
        
        bool temp            = canConnectFromTop;
        canConnectFromTop    = canConnectFromRight;
        canConnectFromRight  = canConnectFromBottom;
        canConnectFromBottom = canConnectFromLeft;
        canConnectFromLeft   = temp;

    }
}
