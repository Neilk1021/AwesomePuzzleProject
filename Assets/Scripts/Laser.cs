using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject _activeLaser;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _interval = 5f;
    [SerializeField] private bool _startsActive = true;
    
    private bool _isActive;
    private float _timer;

    private void Start()
    {
        _isActive = _startsActive;
        _timer = _interval;
        UpdateState();
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = _interval;
            _isActive = !_isActive;
            UpdateState();
        }
    }
    private void UpdateState()
    {
        _activeLaser.SetActive(_isActive);
        _collider.enabled = _isActive;
    }
}
