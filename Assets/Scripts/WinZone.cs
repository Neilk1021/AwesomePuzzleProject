using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Robot") || col.transform.root.CompareTag("Robot"))
            GameOutcomes.Instance?.Win();
    }
}
