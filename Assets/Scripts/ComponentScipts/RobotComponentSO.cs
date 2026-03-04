using UnityEngine;
[CreateAssetMenu(menuName = "RobotComponent Definitions")]
public class RobotComponentSO : ScriptableObject
{
    [Header("Identity")]
    public RobotComponentType type;
    public GameObject prefab;
    public Sprite icon;
    
    [Header("Base Connections")]
    public bool canConnectFromLeft;
    public bool canConnectFromRight;
    public bool canConnectFromTop;
    public bool canConnectFromBottom;
    
    [Header("Stats")]
    public float thrustForce;   // Fan
    public float moveSpeed;     // Wheel
    public float magnetRange;   // Magnet
}
