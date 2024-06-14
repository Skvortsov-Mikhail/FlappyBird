using UnityEngine;
using Zenject;

public class Pipe : MonoBehaviour
{
    [SerializeField] private GameObject m_UpPipe;
    [SerializeField] private GameObject m_DownPipe;

    [SerializeField] private float m_DefaultDistance = 5.0f;
    [SerializeField] private float m_StepByLevel = 0.2f;

    private AudioSource _reachedAudio;

    private bool _isReached;
    public bool IsReached => _isReached;

    private LevelController _levelController;
    private ScoreCollector _scoreCollector;
    [Inject]
    public void Construct(LevelController levelController, ScoreCollector scoreCollector)
    {
        _levelController = levelController;
        _scoreCollector = scoreCollector;
    }

    private void Start()
    {
        _reachedAudio = GetComponentInChildren<AudioSource>();

        _levelController.GameStarted += OnGameStarted;
    }

    private void OnDestroy()
    {
        _levelController.GameStarted -= OnGameStarted;
    }

    public void MovePipe(float speed)
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void MoveToStart(Vector2 startPos)
    {
        transform.position = startPos;
        _isReached = false;
    }

    public void AddPoints(int value)
    {
        _isReached = true;
        _reachedAudio.Play();

        _scoreCollector.AddScore(value);
    }

    private void OnGameStarted()
    {
        float height = m_DefaultDistance - m_StepByLevel * _levelController.CurrentLevel;

        m_UpPipe.transform.localPosition = new Vector2(0, height);
        m_DownPipe.transform.localPosition = new Vector2(0, -height);
    }
}