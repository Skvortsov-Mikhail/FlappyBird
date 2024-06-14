using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    // [SerializeField] private Class m_Object;

    public override void InstallBindings()
    {
        /*
        Container.
            Bind<Class>()
            .FromComponentInNewPrefab(m_Object)
            .AsSingle();
        */
    }
}