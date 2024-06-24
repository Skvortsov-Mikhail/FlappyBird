using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelController : MonoBehaviour
{
    public event Action GameStarted;

    [SerializeField] private GameObject m_GameOverPanel;

    private int _currentLevel = 1;
    public int CurrentLevel => _currentLevel;

    private ScoreCollector _scoreCollector;
    [Inject]
    public void Construct(ScoreCollector scoreCollector)
    {
        _scoreCollector = scoreCollector;
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void SetCurrentLevel(int level)
    {
        _currentLevel = level;
    }

    public void StartGame()
    {
        Time.timeScale = 1;

        _scoreCollector.ScorePanel.SetActive(true);
        GameStarted?.Invoke();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _scoreCollector.ScorePanel.SetActive(false);
        m_GameOverPanel.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}