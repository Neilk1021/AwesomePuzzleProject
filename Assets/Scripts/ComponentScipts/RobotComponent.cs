using Unity.Collections;
using UnityEngine;
using System.Collections.Generic;

public abstract class RobotComponent : MonoBehaviour
{
    public RobotComponentData Data { get;  private set; }
    
    public virtual void Initialize(RobotComponentData data)
    {
        Data = data;
    }
    
}