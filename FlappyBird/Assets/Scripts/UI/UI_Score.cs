using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UI_Score : MonoBehaviour
{
    private Text _text;

    private ScoreCollector _scoreCollector;
    [Inject]
    public void Construct(ScoreCollector scoreCollector)
    {
        _scoreCollector = scoreCollector;
    }

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = _scoreCollector.Score.ToString();

        _scoreCollector.ScoreChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        _scoreCollector.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _text.text = score.ToString();
    }
}