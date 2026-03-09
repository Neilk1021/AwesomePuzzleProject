using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Crate : Crate
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Robot") || collision.gameObject.CompareTag("Robot"))
        {
            GameOutcomes.Instance?.Win();
        }

        if (collision.gameObject.CompareTag("Laser") || collision.gameObject.CompareTag("Lava"))
        {
            Debug.Log("Respawn because special crate touched laser/lava");
            GameOutcomes.Instance?.Lose();
        }
    }
}
