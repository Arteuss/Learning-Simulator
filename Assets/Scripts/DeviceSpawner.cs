using System.Collections.Generic;
using UnityEngine;

public class DeviceSpawner : IDeviceSpawner
{
    private readonly DevicesConfigs _devicesConfigs;
    private List<Device> _simulatorViews = new List<Device>();
    private List<SimulatorScenarioConfig> _simulatorScenarioConfig = new List<SimulatorScenarioConfig>();
    private List<GameObject> _devices = new List<GameObject>();
    
    public DeviceSpawner(DevicesConfigs devicesConfigs)
    {
        _devicesConfigs = devicesConfigs;
        foreach (var scenarioConfig in _devicesConfigs.ScenarioConfigs)
        {
            _simulatorScenarioConfig.Add(scenarioConfig);
            if (scenarioConfig.DevicePrefab)
                Spawn(scenarioConfig.DevicePrefab);
        }
        HideAll();
    }
    
    private void Spawn(GameObject devicePrefab)
    {
        var device = GameObject.Instantiate(devicePrefab);
        var simulatorView = device.GetComponent<Device>();
        if(simulatorView)
            _simulatorViews.Add(simulatorView);
        _devices.Add(device);
    }
    
    public void ShowDevice(int numDevice, out SimulatorScenarioConfig simulatorScenarioConfig, out Device device)
    {
        var deviceGO = _devices[numDevice];
        deviceGO.transform.position = Vector3.zero;
        device = deviceGO.GetComponent<Device>();
        simulatorScenarioConfig = _simulatorScenarioConfig[numDevice];
    }
    
    public void HideAll()
    {
        foreach (var device in _devices)
        {
            device.transform.position = Vector3.one * 100f;
        }    
    }
}