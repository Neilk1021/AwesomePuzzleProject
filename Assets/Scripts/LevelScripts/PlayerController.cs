using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private List<Wheel> _wheels = new List<Wheel>();
    private List<Fan> _fans = new List<Fan>();
    private List<Magnet> _magnets = new List<Magnet>();
    private Rigidbody _rigidbody;

    private bool _magnetsActive;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _wheels.AddRange(GetComponentsInChildren<Wheel>());
        Debug.Log($"{_wheels.Count} wheels found.");
        
        _fans.AddRange(GetComponentsInChildren<Fan>());
        Debug.Log($"{_fans.Count} fans found.");
        
        _magnets.AddRange(GetComponentsInChildren<Magnet>());
        Debug.Log($"{_magnets.Count} magnets found.");
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float thrustInput = Input.GetAxis("Jump");
        bool magnetInput = Input.GetKey(KeyCode.E);

        if (horizontalInput != 0)
        {
            foreach (Wheel wheel in _wheels)
                wheel.ApplyMovement(horizontalInput);
        }

        if (thrustInput > 0)
        {
            foreach (Fan fan in _fans)
                fan.ApplyThrust();
        }

        if (magnetInput)
        {
            _magnetsActive = !_magnetsActive;
            
            foreach (var magnet in _magnets)
            {
                if (_magnetsActive)
                {
                    magnet.Activate();
                }
                else
                {
                    magnet.Deactivate();
                }
            }
        }
    }
}