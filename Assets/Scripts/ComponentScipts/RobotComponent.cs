using Unity.Collections;
using UnityEngine;
using System.Collections.Generic;

public abstract class RobotComponent : MonoBehaviour
{
    public RobotComponentData Data { get;  private set; }
    
    public virtual void Initialize(RobotComponentData data)
    {
        Data = data;
        SyncWithData();
    }

    public void SyncWithData()
    {
        transform.position = new Vector3(Data.GridPosition.x, Data.GridPosition.y, 0);
        
        transform.rotation = Quaternion.Euler(0f, 0f, Data.Rotation);
    }
    


    private void OnMouseDown()
    {
        Debug.Log($"Clicked {name} at {Data.GridPosition}");
    }
}