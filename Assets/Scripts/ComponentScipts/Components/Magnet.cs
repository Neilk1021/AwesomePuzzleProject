using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : RobotComponent
{
    [SerializeField] private Transform _anchorPoint;
    [SerializeField] private CircleCollider2D _sensorCollider;
    [SerializeField] private MagnetSensor _sensor;
    private bool _isActive;

    public override void Initialize(RobotComponentData data)
    {
        base.Initialize(data);
        _sensorCollider.radius = Data.Definition.magnetRange;
        _sensorCollider.enabled = false;
        _sensor.Initialize(this);
    }

    public void OnCrateEnter(Crate crate)
    {
        if (!_isActive) return;
        crate.OnMagnetActivate(this);
    }

    public void OnCrateExit(Crate crate)
    {
        if (!_isActive) return;
        crate.OnMagnetDeactivate(this);
    }
    
    public void Activate()
    {
        Debug.Log("Activating Magnet");
        _isActive = true;
        _sensorCollider.enabled = true;
        
    }

    public void Deactivate()
    {
        Debug.Log("Deactivating Magnet");
        _isActive = false;
        _sensorCollider.enabled = false;
        
        foreach (var crate in FindObjectsOfType<Crate>())
        {
            crate.OnMagnetDeactivate(this);
        }
    }

    public Vector2 GetAnchorPoint()
    {
        return _anchorPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isActive) return;
        if (other.TryGetComponent<Crate>(out var crate))
            crate.OnMagnetActivate(this);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!_isActive) return;
        if (other.TryGetComponent<Crate>(out var crate))
            crate.OnMagnetDeactivate(this);
    }
}