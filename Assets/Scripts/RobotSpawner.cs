using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawner : MonoBehaviour
{
    [SerializeField] private CameraFollow _cameraFollow;
    // Start is called before the first frame update
    void Start()
    {
        GridBuilder gridBuilder = FindObjectOfType<GridBuilder>();

        if (gridBuilder != null)
        {
            GameObject robot = gridBuilder.BuildRobot(); 
            robot.transform.position = transform.position;
            if (_cameraFollow != null && robot != null)
                _cameraFollow = Camera.main.GetComponent<CameraFollow>();
            if (_cameraFollow != null)
                _cameraFollow.SetTarget(robot.transform);
            
            GridManager gridManager = FindObjectOfType<GridManager>();
            if (gridManager != null)
            {
                Destroy(gridManager.gameObject);
            }
        }
    }
}

