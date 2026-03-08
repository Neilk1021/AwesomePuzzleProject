using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public struct CrateSpawn
    {
        public GameObject prefab;
        public Transform spawnPoint;
    }
    
    [SerializeField] private List<CrateSpawn> _crateSpawns;
    private List<GameObject> _activeCrates = new List<GameObject>();

    public void NewStart()
    {
        ClearCrates();
        SpawnCrates();
    }

    private void SpawnCrates()
    {
        foreach (var spawn in _crateSpawns)
        {
            if (spawn.prefab == null || spawn.spawnPoint == null) continue;

            GameObject crate = Instantiate(spawn.prefab, spawn.spawnPoint.position, Quaternion.identity);
            _activeCrates.Add(crate);
        }
    }
    
    private void ClearCrates()
    {
        foreach (var crate in _activeCrates)
            if (crate != null) Destroy(crate);
        _activeCrates.Clear();
    }
}
