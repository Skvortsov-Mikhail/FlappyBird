using UnityEngine;
using Zenject;

public class PipesContainer : MonoBehaviour
{
    private Pipe[] _pipes;
    public Pipe[] AllPipes => _pipes;

    private void Awake()
    {
        _pipes = GetComponentsInChildren<Pipe>();
    }
}