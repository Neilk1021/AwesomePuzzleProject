using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : RobotComponent
{
    public float range = 3f;
    public float pullForce = .25f;

   /* void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D col in hits)
        {
            if (col.CompareTag("Metal"))
            {
                Rigidbody2D rb = col.attachedRigidbody;

                if (Input.GetKey(KeyCode.S)){
                    Vector2 dir = (transform.position - col.transform.position).normalized;
                    rb.AddForce(dir * pullForce);
                }
            }
        }
    }*/
}