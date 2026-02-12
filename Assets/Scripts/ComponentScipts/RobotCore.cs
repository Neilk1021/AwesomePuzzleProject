using UnityEngine;
using System.Collections.Generic;

public class RobotCore : RobotComponent
{
    private List<RobotComponent> _components = new List<RobotComponent>();

    public override void DestroySelf()
    {
        Debug.Log("Core cannot be deleted");
    }

    public override bool ValidConnection(string location)
    {
        return true;
    }
}