using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildSceneManager : MonoBehaviour
{
    [SerializeField] private GridData _gridData;
    [SerializeField] private GridManager _gridManager;
    
    public void OnPlayButtonClicked()
    {
        Debug.Log("Button was clicked"); 
        //SceneManager.LoadScene("Level1");

        if (!_gridData.ValidateBot())
        {
            Debug.Log("Invalid robot only 1 core and all pieces connected");
            return;
        }

        int targetLevel = PlayerPrefs.GetInt("TargetLevel", 1);
        Debug.Log("Loading: Level" + targetLevel);
        SceneManager.LoadScene("Level" + targetLevel);
    }
}
