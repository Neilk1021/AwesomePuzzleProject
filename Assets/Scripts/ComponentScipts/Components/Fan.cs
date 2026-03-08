using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : RobotComponent
{
    private Rigidbody2D _rigidbody;

    public override void Initialize(RobotComponentData data)
    {
        base.Initialize(data);
        _rigidbody = GetComponentInParent<Rigidbody2D>();
    }
    
    public void ApplyThrust()
    {
        if (_rigidbody == null) return;

        float thrust = Data.Definition.thrustForce;
        float angel = ((Data.Rotation + 270) % 360) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(-Mathf.Sin(angel), Mathf.Cos(angel));
        _rigidbody.AddForce(direction * thrust, ForceMode2D.Impulse);
    }
}