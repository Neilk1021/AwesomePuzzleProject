using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : RobotComponent
{

    public override void Initialize(Vector2Int pos)
    {
        base.Initialize(pos);
        canConnectFromRight = true;
    }

}
