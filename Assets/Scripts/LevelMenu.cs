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
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void OpenLevel(int level)
    {
        string sceneName = "Level" + level;
        print("Going to Scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void ClearLevelsUnlockedStatus()
    {
        PlayerPrefs.DeleteKey("UnlockedLevel");
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
}
