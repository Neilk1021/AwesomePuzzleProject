using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : RobotComponent
{
    // Start is called before the first frame update
    void Start()
    {
        Component Grabber = new Component(100, "Grabber", 0.0f, 
            0.0f, 100, false);
    }
}
