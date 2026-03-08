using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GridData _gridData;
    [SerializeField] private GridBuilder _gridBuilder;
    [SerializeField] private GameObject _gridLayer;
    [SerializeField] private BuildRobotManager _robotBuilder;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private RectTransform playButton;
    [SerializeField] private RectTransform gobacktobuildButton;
    
    public bool IsPlaying { get; private set; }

    void Start()
    {
        IsPlaying = false;
        gobacktobuildButton.gameObject.SetActive(false);
        EnterBuildPhase();
    }

    public void EnterPlayState()
    {
        if (IsPlaying) return;

        if (!_gridData.ValidateBot())
        {
            Debug.LogError("Invalid Robot - Please fix");
            return;
        }
        
        playButton.gameObject.SetActive(false);
        gobacktobuildButton.gameObject.SetActive(true);
        _levelManager.NewStart();
        _gridLayer.SetActive(false);
        _robotBuilder.BuildRobot(_gridData);
        
        
        IsPlaying = true;
    }

    public void EnterBuildPhase()
    {
        
        if (!IsPlaying) return;
        
        playButton.gameObject.SetActive(true);
        gobacktobuildButton.gameObject.SetActive(false);
        
        _robotBuilder.DestroyRobot();
        _gridLayer.SetActive(true);
        IsPlaying = false;
        
    }
}
