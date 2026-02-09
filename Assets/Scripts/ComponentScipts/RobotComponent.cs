using Unity.Collections;
using UnityEngine;
using System.Collections.Generic;

public abstract class RobotComponent : MonoBehaviour
{
    public Vector2Int GridPosition {get; set;}
    public RobotCore Core { get; private set;}

    private List<string> _validLocation = new List<string>();

    public virtual void Initialize(RobotCore core)
    {
        Core = core;
        transform.SetParent(core.transform);
    }
}