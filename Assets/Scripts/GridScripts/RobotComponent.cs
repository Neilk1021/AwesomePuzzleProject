using UnityEngine;

public abstract class RobotComponent : MonoBehaviour
{
    public Vector2Int GridPosition {get; set;}
    public RobotCore Core { get; private set;}

    public virtual void Initialize(RobotCore core)
    {
        Core = core;
        transform.SetParent(core.transform);
    }
}