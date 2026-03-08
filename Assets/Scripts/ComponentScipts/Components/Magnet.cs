using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : RobotComponent
{
    [SerializeField] private Transform _anchorPoint;
    
    private CircleCollider2D _collider;
    private bool _isActive;

    public override void Initialize(RobotComponentData data)
    {
        base.Initialize(data);
        _collider = GetComponent<CircleCollider2D>();
        _collider.radius = Data.Definition.magnetRange;
        _collider.enabled = false;
    }

    public void Activate()
    {
        
        _isActive = true;
        _collider.enabled = true;
        
    }

    public void Deactivate()
    {
        _isActive = false;
        _collider.enabled = false;
        
        foreach (var crate in FindObjectsOfType<SpecialCrate>())
        {
            crate.OnMagnetDeactivate(this);
        }
    }

    public Vector2 GetAnchorPoint()
    {
        //float angle = Data.Rotation * Mathf.Deg2Rad;
        //Vector2 facing = new Vector2(-Mathf.Sin(angle), Mathf.Cos(angle));
        //return (Vector2)transform.position + facing * 0.6f;
        
        return _anchorPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isActive) return;
        if (other.TryGetComponent<SpecialCrate>(out var crate))
            crate.OnMagnetActivate(this);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!_isActive) return;
        if (other.TryGetComponent<SpecialCrate>(out var crate))
            crate.OnMagnetDeactivate(this);
    }
}