using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class somethingThatCallsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.PlayBGM("bgm", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AudioManager.PlaySFX("bubble", 1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.PlaySFX("goat", 1);
        }
    }
}
