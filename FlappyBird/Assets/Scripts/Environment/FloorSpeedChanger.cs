using UnityEngine;
using Zenject;

public class FloorSpeedChanger : MonoBehaviour
{
    [SerializeField] private float m_DefaultAnimationSpeed = 1.0f;
    [SerializeField] private float m_SpeedStepByLevel = 0.5f;

    private Animator _animator;

    private LevelController _levelController;
    [Inject]
    public void Construct(LevelController levelController)
    {
        _levelController = levelController;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _animator.speed = m_DefaultAnimationSpeed;

        _levelController.GameStarted += OnGameStarted;
    }

    private void OnDestroy()
    {
        _levelController.GameStarted -= OnGameStarted;
    }

    private void OnGameStarted()
    {
        SetNewSpeed();
    }

    private void SetNewSpeed()
    {
        _animator.speed = m_DefaultAnimationSpeed + (_levelController.CurrentLevel - 1) * m_SpeedStepByLevel;
    }
}