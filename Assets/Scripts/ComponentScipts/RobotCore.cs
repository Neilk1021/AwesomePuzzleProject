using UnityEngine;
using System.Collections.Generic;

public class RobotCore : RobotComponent
{
    private List<RobotComponent> _components = new List<RobotComponent>();

    public void AddComponent(RobotComponent component)
    {
        _components.Add(component);
    }
    public void RemoveComponent(RobotComponent component)
    {
        _components.Remove(component);
    }
    public override void DestroySelf()
    {
        Debug.Log("Core cannot be deleted");
    }

    public override bool ValidConnection(string location)
    {
        return true;
    }
}