using UnityEngine;
using Zenject;

public class ScoreCollectorInstaller : MonoInstaller
{
    [SerializeField] private ScoreCollector m_ScoreCollector;

    public override void InstallBindings()
    {
        BindScoreCollector();
    }

    private void BindScoreCollector()
    {
        Container.
            Bind<ScoreCollector>().FromInstance(m_ScoreCollector).AsSingle();
    }
}