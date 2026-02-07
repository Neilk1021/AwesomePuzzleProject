using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propellor : RobotComponent
{
    // Start is called before the first frame update
    void Start()
    {
        Component Propellor = new Component(75, "Propellor", 0.0f, 
            0.0f, 250, false); 
    }
}
