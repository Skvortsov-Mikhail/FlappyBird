using System;
using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    public Action<int> ScoreChanged;

    [SerializeField] private GameObject m_ScorePanel;
    public GameObject ScorePanel => m_ScorePanel;

    private int _score;
    public int Score => _score;

    public void AddScore(int count)
    {
        _score += count;
        ScoreChanged?.Invoke(_score);
    }
}