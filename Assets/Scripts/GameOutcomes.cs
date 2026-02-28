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

    private bool _triggered = false;

    void Awake()
    {
        Instance = this;
    }

    public void Win()
    {
        if (_triggered) return;
        _triggered = true;
        StartCoroutine(OutcomeSequence(_winUI));
    }

    public void Lose()
    {
        if (_triggered) return;
        _triggered = true;
        StartCoroutine(OutcomeSequence(_loseUI));
    }

    private IEnumerator OutcomeSequence(GameObject ui)
    {
        if (ui != null) ui.SetActive(true);
        Time.timeScale = 0.3f; // ← Slow mo effect!
        yield return new WaitForSecondsRealtime(_delay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(_levelSelectScene);
    }
}
