using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Component Library")]
public class ComponentLibrarySO : ScriptableObject
{
    public List<RobotComponentSO> components;
    
    private Dictionary<RobotComponentType, RobotComponentSO> _dict;
    
    public void Initalize()
    {
        _dict = new Dictionary<RobotComponentType, RobotComponentSO>();
        foreach (var component in components)
            _dict[component.type] = component;
        
    }
    
    public RobotComponentSO Get(RobotComponentType type) => _dict.ContainsKey(type) ? _dict[type] : null;

    public GameObject GetPrefab(RobotComponentType type) => Get(type)?.prefab;
}
