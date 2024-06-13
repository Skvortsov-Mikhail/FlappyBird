using UnityEngine;

public class BirdMovementController : MonoBehaviour
{
    [SerializeField] private Transform m_BirdStartPos;
    public Transform BirdStartPosition => m_BirdStartPos;

    [SerializeField] private float m_Force = 1.0f;

    private LevelController _levelController;

    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();

        _levelController = _bird.LevelController;
        _levelController.GameStarted += OnGameStarted;
    }

    private void OnDestroy()
    {
        _levelController.GameStarted -= OnGameStarted;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _bird.FlyUp(m_Force);
        }
    }

    private void OnGameStarted()
    {
        _bird.transform.position = m_BirdStartPos.position;
    }
}