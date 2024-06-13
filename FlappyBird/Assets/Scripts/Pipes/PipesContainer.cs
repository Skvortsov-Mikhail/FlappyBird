using UnityEngine;

public class PipesContainer : MonoBehaviour
{
    [SerializeField] private LevelController m_LevelController;
    public LevelController LevelController => m_LevelController;

    private Pipe[] _pipes;
    public Pipe[] PipesArray => _pipes;

    private void Awake()
    {
        _pipes = GetComponentsInChildren<Pipe>();
    }
}
