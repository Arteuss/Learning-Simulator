using System;

public interface ISimulatorModel
{
    /// <summary>
    /// Обработка выбора устройства
    /// </summary>
    /// <param name="num">id устройства</param>
    void OnSelectDevice(int num);
    
    /// <summary>
    /// Рестарт устройств на сцене
    /// </summary>
    void Restart();
    
    /// <summary>
    /// Событие обновления ui
    /// </summary>
    event Action<DataForUi> UpdateUi;
//    event Action<string, bool, bool> UpdateUi;

}