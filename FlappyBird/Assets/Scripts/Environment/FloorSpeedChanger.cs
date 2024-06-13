using UnityEngine;

public class FloorSpeedChanger : MonoBehaviour
{
    [SerializeField] private LevelController m_LevelController;
    [SerializeField] private float m_DefaultAnimationSpeed = 1.0f;
    [SerializeField] private float m_SpeedStepByLevel = 0.5f;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _animator.speed = m_DefaultAnimationSpeed;

        m_LevelController.GameStarted += OnGameStarted;
    }

    private void OnDestroy()
    {
        m_LevelController.GameStarted -= OnGameStarted;
    }

    private void OnGameStarted()
    {
        SetNewSpeed();
    }

    private void SetNewSpeed()
    {
        _animator.speed = m_DefaultAnimationSpeed + (m_LevelController.CurrentLevel - 1) * m_SpeedStepByLevel;
    }
}