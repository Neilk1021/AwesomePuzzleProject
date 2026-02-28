using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{

    // ← For lava (solid collider)
    void OnCollisionEnter2D(Collision2D col)
    {
	    if (col.gameObject.CompareTag("Robot") || col.transform.root.CompareTag("Robot"))
		    GameOutcomes.Instance?.Lose();
    }

    // ← For laser (trigger collider - Is Trigger = true)
    void OnTriggerEnter2D(Collider2D col)
    {
	    if (col.gameObject.CompareTag("Robot") || col.transform.root.CompareTag("Robot"))
		    GameOutcomes.Instance?.Lose();
    }
}
