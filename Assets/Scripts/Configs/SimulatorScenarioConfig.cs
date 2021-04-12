using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SimulatorCreator/SimulatorScenario", fileName = "SimulatorScenario")]
public class SimulatorScenarioConfig : ScriptableObject
{
    [SerializeField] private GameObject _devicePrefab;
    [SerializeField] private List<ElementConfig> _elementConfigs = new List<ElementConfig>();

    public GameObject DevicePrefab => _devicePrefab;

    public List<ElementConfig> ElementConfigs => _elementConfigs;
}