using UnityEngine;
using System.Collections.Generic;

public class ComponentPrefabLibrary : MonoBehaviour
{
    [System.Serializable] public struct Entry
    {
        public RobotComponentType type;
        public GameObject prefab;
    }
    
    [SerializeField] private List<Entry> _Entries;

    private Dictionary<RobotComponentType, GameObject> _dict;

    private void Awake()
    {
        _dict = new Dictionary<RobotComponentType, GameObject>();

        foreach (var entry in _Entries)
        {
            _dict.Add(entry.type, entry.prefab);
        }
    }

    public GameObject GetPrefab(RobotComponentType type)
    {
        if (_dict.ContainsKey(type))
        {
            return _dict[type];
        }
        
        return null;
    }
}