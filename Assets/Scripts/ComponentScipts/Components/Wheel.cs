using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : RobotComponent
{
    private Rigidbody2D _rigidbody;

    public override void Initialize(RobotComponentData data)
    {
        base.Initialize(data);
        _rigidbody = GetComponentInParent<Rigidbody2D>();
        Debug.Log(_rigidbody == null);
        
    }

    public void ApplyMovement(float input)
    {
        if (_rigidbody == null) return;

        float speed = Data.Definition.moveSpeed;
        _rigidbody.velocity = new Vector2(input * speed, _rigidbody.velocity.y);
    }
}
