using ProjectUI;
using UnityEngine;
using Zenject;

public class SystemInstaller : MonoInstaller
{
    [SerializeField] private DevicesConfigs _devicesConfigs;
        
    public override void InstallBindings()
    {
        Container.Bind<UiView>().FromComponentInHierarchy().AsSingle();
        Container.BindInstance(_devicesConfigs).AsSingle();
        Container.QueueForInject(_devicesConfigs);
        Container.BindInterfacesAndSelfTo<UiController>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<DeviceSpawner>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<SimulatorModel>().AsSingle().NonLazy();
    }
}