using UnityEngine;
using Zenject;

public class PointsAdder : MonoBehaviour
{
    [SerializeField] private int m_Points = 1;

    private Pipe _pipe;

    private Bird _bird;
    [Inject]
    public void Construct(Bird bird)
    {
        _bird = bird;
    }

    private Vector3 _birdPosition;

    private void Start()
    {
        _pipe = GetComponent<Pipe>();

        _birdPosition = _bird.BirdStartPosition.position;
    }

    private void Update()
    {
        TryAddPoints();
    }

    private void TryAddPoints()
    {
        if (!_pipe.IsReached && transform.position.x <= _birdPosition.x)
        {
            _pipe.AddPoints(m_Points);
        }
    }
}