using UnityEngine;
using Zenject;

public class BirdInstaller : MonoInstaller
{
    [SerializeField] private Bird m_Bird;

    public override void InstallBindings()
    {
        BindBird();
    }

    private void BindBird()
    {
        Container.
            Bind<Bird>().FromInstance(m_Bird).AsSingle();
    }
}