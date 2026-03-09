using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class RobotCollisions : MonoBehaviour
// {
//     void OnCollisionEnter2D(Collision2D col)
//     {
//         Debug.Log($"Robot hit: {col.gameObject.name} tag: {col.gameObject.tag}");
//
//         if (col.gameObject.CompareTag("Lava"))
//             GameOutcomes.Instance?.Lose();
//
//         if (col.gameObject.CompareTag("Win"))
//             GameOutcomes.Instance?.Win();
//     }
//
//     void OnTriggerEnter2D(Collider2D col)
//     {
//         Debug.Log($"Robot triggered: {col.gameObject.name} tag: {col.gameObject.tag}");
//
//         if (col.gameObject.CompareTag("Laser"))
//             GameOutcomes.Instance?.Lose();
//     }
// }
