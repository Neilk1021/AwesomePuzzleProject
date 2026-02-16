using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class somethingThatCallsManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.PlayBGM("bgm", 1);
        volumeSlider.onValueChanged.AddListener((v) =>
        {
            AudioManager.SetMasterVolume(v);
        });
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
