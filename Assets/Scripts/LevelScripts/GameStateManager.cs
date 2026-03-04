using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GridData _gridData;
    [SerializeField] private GridBuilder _gridBuilder;
    [SerializeField] private GameObject _gridLayer;
    //[SerializeField] private RobotBuilder _robotBuilder;
    
    public bool IsPlaying { get; private set; }

    public void EnterPlayState()
    {
        if (IsPlaying) return;

        if (!_gridData.ValidateBot())
        {
            Debug.LogError("Invalid Robot - Please fix");
            return;
        }
        
        _gridLayer.SetActive(false);
        //_robotBuilder.BuildRobot(_gridData);
        IsPlaying = true;
    }

    public void EnterBuildPhase()
    {
        
        if (!IsPlaying) return;
        
        //_robotBuilder.DestroyRobot();
        _gridLayer.SetActive(true);
        IsPlaying = false;
        
    }
}
