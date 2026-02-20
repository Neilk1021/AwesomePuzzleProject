using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : RobotComponent
{
    public override void Initialize(Vector2Int pos, int rotation = 0)
    {
        base.Initialize(pos);
        canConnectFromBottom = true;
        baseTop = false;
        baseBottom = true;
        baseLeft = false;
        baseRight = false;
    }

}
