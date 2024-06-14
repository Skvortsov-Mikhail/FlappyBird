using UnityEngine;

public class BirdVisualModel : MonoBehaviour
{
    [SerializeField] private float m_RotateAngle = 25.0f;

    private Rigidbody2D _birdRB;

    private void Start()
    {
        _birdRB = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        RotateVisualModel();
    }

    private void RotateVisualModel()
    {
        transform.localRotation = Quaternion.Euler(0, 0, m_RotateAngle * _birdRB.velocity.normalized.y);
    }
}