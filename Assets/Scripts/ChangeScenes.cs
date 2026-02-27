using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    
    public void GoToLevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }

	public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
