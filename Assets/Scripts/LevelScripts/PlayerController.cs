using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private List<Wheel> _wheels = new List<Wheel>();
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _wheels.AddRange(GetComponentsInChildren<Wheel>());
        Debug.Log($"{_wheels.Count} wheels found.");
    }

    private void FixedUpdate()
    {
        float input = Input.GetAxis("Horizontal");
        
        foreach (Wheel wheel in _wheels)
            wheel.ApplyMovement(input);
    }
}