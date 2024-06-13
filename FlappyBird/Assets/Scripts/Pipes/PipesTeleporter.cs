using UnityEngine;

public class PipesTeleporter : MonoBehaviour
{
    [SerializeField] private Transform m_LeftBound;
    [SerializeField] private Transform m_RightBound;
    [SerializeField] private float m_PipeSpawnMinHeight;
    [SerializeField] private float m_PipeSpawnMaxHeight;

    private Pipe[] _pipes;

    private void Start()
    {
        _pipes = GetComponent<PipesContainer>().PipesArray;

        foreach (var pipe in _pipes)
        {
            pipe.transform.position += new Vector3(0, Random.Range(m_PipeSpawnMinHeight, m_PipeSpawnMaxHeight), 0);
        }
    }

    private void Update()
    {
        foreach (var pipe in _pipes)
        {
            if (pipe.transform.position.x <= m_LeftBound.position.x)
            {
                pipe.MoveToStart(GetNewStartPosition());
            }
        }
    }

    private Vector2 GetNewStartPosition()
    {
        Vector2 newPosition = new Vector2(m_RightBound.transform.position.x, Random.Range(m_PipeSpawnMinHeight, m_PipeSpawnMaxHeight));

        return newPosition;
    }
}