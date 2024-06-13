using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private LevelController m_LevelController;

    [SerializeField] private GameObject m_UpPipe;
    [SerializeField] private GameObject m_DownPipe;
    [SerializeField] private Bird m_Bird;
    public Bird Bird => m_Bird;

    [SerializeField] private float m_DefaultDistance = 5.0f;
    [SerializeField] private float m_StepByLevel = 0.2f;

    private AudioSource _reachedAudio;

    private bool _isReached;
    public bool IsReached => _isReached;

    private void Start()
    {
        _reachedAudio = GetComponentInChildren<AudioSource>();

        m_LevelController.GameStarted += OnGameStarted;
    }

    private void OnDestroy()
    {
        m_LevelController.GameStarted -= OnGameStarted;
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

        m_LevelController.ScoreCollector.AddScore(value);
    }

    private void OnGameStarted()
    {
        float height = m_DefaultDistance - m_StepByLevel * m_LevelController.CurrentLevel;

        m_UpPipe.transform.localPosition = new Vector2(0, height);
        m_DownPipe.transform.localPosition = new Vector2(0, -height);
    }
}