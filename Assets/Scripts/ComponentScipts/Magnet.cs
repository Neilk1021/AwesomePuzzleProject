using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : RobotComponent
{
    public override void Initialize(Vector2Int pos)
    {
        base.Initialize(pos);
        canConnectFromBottom = true;
    }

}
