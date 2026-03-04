using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : RobotComponent
{
    [SerializeField] private float _thrust = 2f;
    [SerializeField] private float _maxThrust = 8f;
    [SerializeField] private Vector2 _localThrustDir = Vector2.up;
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
        if (_allFans[0] != this) return;

        if (Input.GetKey(KeyCode.Space))
        {
            float totalThrust = Mathf.Min(_thrust * _allFans.Count, _maxThrust);
            Vector2 worldDir = transform.TransformDirection(_localThrustDir);
            _rb.AddForce(Vector2.up  * totalThrust);
        }
    }
}