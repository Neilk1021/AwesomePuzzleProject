using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _smoothSpeed = 5f;
    [SerializeField] private float _lookAheadDistance = 6f;

    private Transform _target;
    private Rigidbody _targetrb;
    private bool _isFollowing;

    private static readonly Vector3 BuildModePosition = new Vector3(0, 0, -10);

    public void FollowTarget(Transform target)
    {
        _target = target;
        _targetrb = _target.GetComponent<Rigidbody>();
        _isFollowing = true;
    }

    public void ReturnToBuildMode()
    {
        _target = null;
        _isFollowing = false;
        transform.position = BuildModePosition;
    }

    private void LateUpdate()
    {
        if (!_isFollowing || _target == null) return;

        Vector3 lookAhead = Vector3.zero;
        if(_targetrb != null)
            lookAhead = (Vector3)_targetrb.velocity.normalized * _lookAheadDistance;
        
        Vector3 targetPos = new  Vector3(_target.position.x + lookAhead.x, _target.position.y + lookAhead.y, -10f);
        transform.position = Vector3.Lerp(transform.position, targetPos, _smoothSpeed * Time.deltaTime);
    }
}
