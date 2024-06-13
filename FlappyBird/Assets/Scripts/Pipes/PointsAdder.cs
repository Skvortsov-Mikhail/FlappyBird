using UnityEngine;

public class PipeScorer : MonoBehaviour
{
    [SerializeField] private int m_Points = 1;

    private Pipe _pipe;
    private Vector3 _birdPosition;

    private void Start()
    {
        _pipe = GetComponent<Pipe>();
        _birdPosition = _pipe.Bird.GetComponent<BirdMovementController>().BirdStartPosition.position;
    }

    private void Update()
    {
        if (!_pipe.IsReached && transform.position.x <= _birdPosition.x)
        {
            _pipe.AddPoints(m_Points);
        }
    }
}