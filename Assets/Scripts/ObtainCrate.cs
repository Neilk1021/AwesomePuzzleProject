using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obtainCrate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            System.Console.WriteLine("Got the crate! :3");
        }
    }
}
