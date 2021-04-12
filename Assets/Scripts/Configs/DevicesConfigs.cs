using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SimulatorCreator/DevicesConfigs", fileName = "DevicesConfigs")]
public class DevicesConfigs : ScriptableObject
{
    [SerializeField] private List<SimulatorScenarioConfig> _scenarioConfigs;

    public List<SimulatorScenarioConfig> ScenarioConfigs => _scenarioConfigs;
}