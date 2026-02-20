using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : RobotComponent
{
    public override void Initialize(Vector2Int pos, int rotation = 0)
    {
        base.Initialize(pos);
        canConnectFromTop = true;
        baseTop = true;
        baseBottom = false;
        baseLeft = false;
        baseRight = false;
    }

}
