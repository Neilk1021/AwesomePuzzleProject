using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject PausePanel;
    
    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void Unpause()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }


}
