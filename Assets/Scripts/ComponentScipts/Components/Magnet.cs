using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : RobotComponent
{
    // [SerializeField] private float range = 3f;
    // [SerializeField] private float pullForce = .25f;
    // [SerializeField] private float attachDistance = 0.6f;
    // private Rigidbody2D _heldRb = null;
    //
    // private FixedJoint2D _joint = null;
    //
    // private readonly Collider2D[] _hitBuffer = new Collider2D[10];

    // void Update()
    // {
    //
    //     // ← NonAlloc = no GC allocation, reuses _hitBuffer
    //     int count = Physics2D.OverlapCircleNonAlloc(transform.position, range, _hitBuffer);
    //
    //     for (int i = 0; i < count; i++)
    //     {
    //         Collider2D col = _hitBuffer[i];
    //         if (!col.CompareTag("Pickup")) continue;
    //
    //         // ← TryGetComponent = no null check needed, one call!
    //         if (!col.TryGetComponent(out Rigidbody2D rb)) continue;
    //
    //         float dist = Vector2.Distance(transform.position, col.transform.position);
    //
    //         if (dist < attachDistance)
    //         {
    //             AttachObject(rb);
    //             break; // ← Stop checking once attached
    //         }
    //
    //         Vector2 dir = ((Vector2)transform.position - rb.position).normalized;
    //         rb.AddForce(dir * pullForce);
    //     }
    // }
    //
    // private void AttachObject(Rigidbody2D rb)
    // {
    //     _heldRb = rb;
    //
    //     // ← FixedJoint2D is better than parenting - proper physics constraint!
    //     _joint = gameObject.AddComponent<FixedJoint2D>();
    //     _joint.connectedBody = rb;
    //     _joint.autoConfigureConnectedAnchor = true;
    //
    //     //Debug.Log($"Magnet picked up: {rb.name}");
    // }

}