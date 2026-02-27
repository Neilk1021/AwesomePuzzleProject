using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Find GridBuilder that survived scene change (DontDestroyOnLoad)
        GridBuilder gridBuilder = FindObjectOfType<GridBuilder>();
        
        if (gridBuilder != null)
        {
            GameObject robot = gridBuilder.BuildRobot();
            
            if (robot != null)
            {
                Debug.Log("Robot spawned successfully!");
                // robot.AddComponent<PlayerController>(); // Add later
            }
        }
        else
        {
            Debug.LogError("GridBuilder not found");
        }
    }  
}


