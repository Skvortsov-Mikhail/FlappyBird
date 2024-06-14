using UnityEngine;
using Zenject;

public class SettingsControllerInstaller : MonoInstaller
{
    [SerializeField] private SettingsController m_SettingsController;

    public override void InstallBindings()
    {
        BindSettingsController();
    }

    private void BindSettingsController()
    {
        Container.
            Bind<SettingsController>().FromInstance(m_SettingsController).AsSingle();
    }
}