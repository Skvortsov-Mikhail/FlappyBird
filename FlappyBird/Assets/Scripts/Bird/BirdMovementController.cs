using UnityEngine;
using Zenject;

public class BirdMovementController : MonoBehaviour
{
    [SerializeField] private float m_Force = 1.0f;

    private LevelController _levelController;
    private Bird _bird;
    [Inject]
    public void Construct(LevelController levelController, Bird bird)
    {
        _levelController = levelController;
        _bird = bird;
    }

    private Transform _birdStartPos;

    private void Start()
    {
        _birdStartPos = _bird.BirdStartPosition;

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
        _bird.transform.position = _birdStartPos.position;
    }
}