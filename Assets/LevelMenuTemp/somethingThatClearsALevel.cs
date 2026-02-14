using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class somethingThatClearsALevel : MonoBehaviour
{
    [Tooltip("Enter the current level (Ex. 1 for Level 1)")]
    [SerializeField] private int levelNumber;
    public void UnlockNextLevel()
    {
        int nextLevel = levelNumber + 1;
        int maxUnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        if (nextLevel > maxUnlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", nextLevel);
        }
    }

    public void ReturnToLevelsMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }
}
