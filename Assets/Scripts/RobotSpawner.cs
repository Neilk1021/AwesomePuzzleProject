using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GridBuilder gridBuilder = FindObjectOfType<GridBuilder>();

        if (gridBuilder != null)
        {
            gridBuilder.BuildRobot();
            GridManager gridManager = FindObjectOfType<GridManager>();
            if (gridManager != null)
            {
                Destroy(gridManager.gameObject);
            }
        }
    }
}

