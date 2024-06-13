using UnityEngine;

public class PipesMover : MonoBehaviour
{
    [SerializeField] private float m_DefaultMovingSpeed = 1.0f;
    [SerializeField] private float m_IncreaseSpeedStepByLevel = 0.5f;

    private float _currentSpeed;

    private PipesContainer _container;
    private Pipe[] _pipes;

    private LevelController _levelController;

    private void Start()
    {
        _container = GetComponent<PipesContainer>();
        _pipes = _container.PipesArray;

        _levelController = _container.LevelController;
        _levelController.GameStarted += OnGameStarted;
    }

    private void OnDestroy()
    {
        _levelController.GameStarted -= OnGameStarted;
    }

    private void Update()
    {
        foreach (var pipe in _pipes)
        {
            pipe.MovePipe(_currentSpeed);
        }
    }

    private void OnGameStarted()
    {
        _currentSpeed = m_DefaultMovingSpeed + m_IncreaseSpeedStepByLevel * (_levelController.CurrentLevel - 1);
    }
}