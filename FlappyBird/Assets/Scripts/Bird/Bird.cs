using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private LevelController m_LevelController;
    public LevelController LevelController => m_LevelController;

    [SerializeField] private AudioSource m_FlyAudio;
    [SerializeField] private AudioSource m_DieAudio;

    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    public void FlyUp(float force)
    {
        if (Time.timeScale == 0) return;

        _rigidBody.velocity = Vector2.up * force;

        m_FlyAudio.Play();
    }

    private void Die()
    {
        m_DieAudio.Play();

        m_LevelController.GameOver();
    }
}