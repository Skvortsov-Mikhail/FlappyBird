using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    [SerializeField] private ScoreCollector m_ScoreCollector;

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = m_ScoreCollector.Score.ToString();

        m_ScoreCollector.ScoreChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        m_ScoreCollector.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _text.text = score.ToString();
    }
}