using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : RobotComponent
{

    public override void Initialize(Vector2Int pos, int rotation = 0)
    {
        base.Initialize(pos);
        canConnectFromRight = true;
        baseTop = false;
        baseBottom = false;
        baseLeft = false;
        baseRight = true;
    }

}
