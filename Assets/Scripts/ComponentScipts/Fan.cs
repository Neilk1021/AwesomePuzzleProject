using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : RobotComponent
{
    [SerializeField] private float _thrust = .01f;
    [SerializeField] private float _maxThrust = .2f;
    private Rigidbody2D _rb;
    private List<Fan> _allFans;

    void Start()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
        _allFans = new List<Fan>(
            transform.root.GetComponentsInChildren<Fan>()
        );
    }

    void Update()
    {
        //if (_rb == null) return;
        if (_allFans[0] != this) return; // Only first fan drives

        if (Input.GetKey(KeyCode.Space))
        {
            // More fans = more upward speed, capped at maxThrust
            float totalThrust = Mathf.Min(_thrust * _allFans.Count, _maxThrust);
            _rb.AddForce(Vector2.up * totalThrust);
        }
    }
}
