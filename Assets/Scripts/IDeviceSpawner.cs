public interface IDeviceSpawner
{
    /// <summary>
    /// Показать выбранное устройство
    /// </summary>
    /// <param name="numDevice">id устройство</param>
    /// <param name="simulatorScenarioConfig">Конфиг сценария обучения</param>
    /// <param name="device">Устройство</param>
    void ShowDevice(int numDevice, out SimulatorScenarioConfig simulatorScenarioConfig, out Device device);
        
    /// <summary>
    /// Скрыть все устройства
    /// </summary>
    void HideAll();
}