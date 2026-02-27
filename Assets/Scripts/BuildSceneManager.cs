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
        Debug.Log("Button was clicked!"); 
        
        if (_gridData == null)
        {
            Debug.LogError("GridData is NULL! Assign it in Inspector!"); // ← Will show red
            return;
        }

        if (!_gridData.ValidateBot())
        {
            Debug.Log("Validation FAILED"); 
            return;
        }

        int targetLevel = PlayerPrefs.GetInt("TargetLevel", 1);
        Debug.Log("Loading: Level" + targetLevel);
        SceneManager.LoadScene("Level" + targetLevel);
    }
}
