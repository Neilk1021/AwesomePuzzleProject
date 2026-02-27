using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [Tooltip("Put the parent of the level buttons here. (Make sure the children are in order)")]
    [SerializeField] private GameObject levelButtons;
    private Button[] buttons;
    public void Awake()
    {
        SetUpButtons();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        DisableLockedLevels(unlockedLevel);
    }
    /// <summary>
    /// Call this function to open Scene with name Level[level].
    /// Ex. OpenLevel(2) will load scene "Level2"
    /// </summary>
    /// <param name="level"></param>
    public void OpenLevel(int level)
    {
        PlayerPrefs.SetInt("TargetLevel", level);
        //string sceneName = "Level" + level;
        //print("Going to Scene: " + sceneName);
        SceneManager.LoadScene("grid + palette");
    }

    public void ClearLevelsUnlockedStatus()
    {
        PlayerPrefs.DeleteKey("UnlockedLevel");
        DisableLockedLevels();
    }

    private void SetUpButtons()
    {
        int childCount = levelButtons.transform.childCount;
        buttons = new Button[childCount];
        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }

    private void DisableLockedLevels(int unlockedLevel=1)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
