using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    //Is something attached and what is that thing (not necessary)?
    public bool attachedUp = false;
    public bool attachedDown = false;
    public bool attachedLeft = false;
    public bool attachedRight = false;
    
    [SerializeField] private Robot objectUp;
    [SerializeField] private Robot objectDown;
    [SerializeField] private Robot objectLeft;
    [SerializeField] private Robot objectRight;
    
    // Start is called before the first frame update
    void Start()
    {
        Component Robot = new Component(500, "Robot", 0.0f, 
            0.0f, 500, false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
