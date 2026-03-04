using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : RobotComponent
{
    [SerializeField] private float _speed = 30f;
    [SerializeField] private float _maxSpeed = 1000f; 
    private Rigidbody2D _rb;
    private List<Wheel> _allWheels;

    void Start()
    {
        _rb = GetComponentInParent<Rigidbody2D>();

        // Find all wheels on this robot
        _allWheels = new List<Wheel>(
            GetComponentsInParent<Transform>()[0].GetComponentsInChildren<Wheel>()
        );
    }

    void Update()
    {
        //if (_rb == null) return;

        // Only the first wheel controls movement (avoids duplicate calls)
        if (_allWheels[0] != this) return;

        float moveInput = 0f;
        if (Input.GetKey(KeyCode.D)) moveInput = 1f;
        if (Input.GetKey(KeyCode.A)) moveInput = -1f;

        // More wheels = faster, but capped at maxSpeed
        float totalSpeed = Mathf.Min(_speed * _allWheels.Count, _maxSpeed);
        
        print("Wheel update: " + totalSpeed + " speed");
        _rb.velocity = new Vector2(moveInput * totalSpeed, _rb.velocity.y);
    }
}
