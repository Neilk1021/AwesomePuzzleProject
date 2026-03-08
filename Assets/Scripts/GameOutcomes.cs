using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOutcomes : MonoBehaviour
{
    public static GameOutcomes Instance { get; private set; }

    [SerializeField] private GameObject _winUI;
    [SerializeField] private GameObject _loseUI;
    [SerializeField] private string _levelSelectScene = "LevelMenu";
    [SerializeField] private float _delay = 2f;
    
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private BuildRobotManager _buildRobotManager;
    [SerializeField] private CameraFollow _cameraFollow;

    private bool _triggered;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public void Win()
    {
        if (_triggered) return;
        _triggered = true;
        StartCoroutine(WinSequence());
    }

    public void Lose()
    {
        if (_triggered) return;
        _triggered = true;
        StartCoroutine(LoseSequence());
        
        
    }

    private IEnumerator WinSequence()
    {
        if (_winUI != null) _winUI.SetActive(true);
        Time.timeScale = 0.3f; // ← Slow mo effect!
        yield return new WaitForSecondsRealtime(_delay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(_levelSelectScene);
    }

    private IEnumerator LoseSequence()
    {
        if(_loseUI != null) _loseUI.SetActive(true);
        Time.timeScale = 0.3f;
        yield return new WaitForSecondsRealtime(_delay);
        Time.timeScale = 1f;
        Respawn();
    }

    private void Respawn()
    {
        _triggered = false;
        if(_loseUI != null) _loseUI.SetActive(false);

        GameObject robot = _buildRobotManager.RebuildRobot();
        _levelManager.NewStart();

        
        if(robot != null)
            _cameraFollow.FollowTarget(robot.transform);
    }
}
