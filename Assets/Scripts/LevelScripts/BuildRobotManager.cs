using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Resonsible for spawning the finalized physics robot
///  NO KNOWLEDGE OF GRID UI - Reads GridData and builds
/// </summary>
public class BuildRobotManager : MonoBehaviour
{
    [SerializeField] private ComponentLibrarySO componentLibrary;
    [SerializeField] private Transform _spawnPoint;

    private GameObject _activeRobot;
    private GridData _lastGridData;

    public GameObject BuildRobot(GridData gridData)
    {
        _lastGridData = gridData;
        DestroyRobot();
        
        RobotComponentData coreData = FindCore(gridData);
        if (coreData == null)
        {
            return null;
        }
        
        GameObject coreObj = SpawnCore(coreData, _spawnPoint.position);
        
        
        AttachPhysics(coreObj);
        SpawnComponents(gridData, coreData, coreObj);
        coreObj.AddComponent<PlayerController>();
        
        _activeRobot = coreObj;
        coreObj.tag = "Robot";
        Debug.Log("Spawned robot.");
        return _activeRobot;
    }

    public GameObject RebuildRobot()
    {
        Debug.Log("Rebuilding robot...");
        if(_lastGridData != null)
            return BuildRobot(_lastGridData);

        return null;
    }

    private void SpawnComponents(GridData gridData, RobotComponentData coreData, GameObject coreObj)
    {
        for (int row = 0; row < gridData.height; row++)
        {
            for (int col = 0; col < gridData.width; col++)
            {
                RobotComponentData data = gridData.Get(row, col);
                if (data == null || data.IsCore) continue;
                
                GameObject prefab = componentLibrary.GetPrefab(data.Type);
                if (prefab == null) continue;
                
                Vector2Int gridOffset = data.GridPosition - coreData.GridPosition;
                Vector3 localpos = new Vector3(gridOffset.y, -gridOffset.x, 0);
                
                GameObject obj = Instantiate(prefab, coreObj.transform);
                obj.transform.localPosition = localpos;
                obj.transform.localRotation = Quaternion.Euler(0, 0, data.Rotation);
                obj.name = data.Type.ToString();
                obj.layer = LayerMask.NameToLayer("Robot");
                
                
                if (obj.TryGetComponent<RobotComponent>(out var comp))
                    comp.Initialize(data);
            }
        }
    }
    

    public void DestroyRobot()
    {
        if (_activeRobot != null)
        {
            Destroy(_activeRobot);
            _activeRobot = null;
        }
    }


    private RobotComponentData FindCore(GridData gridData)
    {
        for (int row = 0; row < gridData.height; row++)
        {
            for (int col = 0; col < gridData.width; col++)
            {
                var data = gridData.Get(row, col);
                if (data != null && data.IsCore) return data;
            }
        }
        return null;
    }

    private GameObject SpawnCore(RobotComponentData coreData, Vector3 spawnPoint)
    {
        GameObject prefab = componentLibrary.GetPrefab(coreData.Type);
        GameObject coreObj = Instantiate(prefab, spawnPoint, Quaternion.Euler(0, 0, coreData.Rotation));
        coreObj.name = "Core";
        
        if (coreObj.TryGetComponent<RobotComponent>(out var comp))
            comp.Initialize(coreData);
        
        coreObj.layer = LayerMask.NameToLayer("Robot");
        
        return coreObj;
    }

    private void AttachPhysics(GameObject coreObj)
    {
        Rigidbody2D coreRB = coreObj.AddComponent<Rigidbody2D>();
        coreRB.gravityScale = 1f;
        coreRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        coreRB.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }
    
    
}
