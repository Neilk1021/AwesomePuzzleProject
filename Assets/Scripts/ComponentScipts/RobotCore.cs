using UnityEngine;
using System.Collections.Generic;

public class RobotCore : MonoBehaviour
{
    private List<RobotComponent> _components = new List<RobotComponent>();

    public void AddComponent(RobotComponent component)
    {
        _components.Add(component);
        component.Initialize(this);
    }
}