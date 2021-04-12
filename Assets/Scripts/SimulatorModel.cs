using System;
using System.Collections.Generic;
using System.Linq;

public class SimulatorModel : ISimulatorModel
{
    private Queue<EntryAction> _actions;
    private IDeviceSpawner _spawner;
    private SimulatorScenarioConfig _simulatorScenarioConfig;
    public event Action<DataForUi> UpdateUi;
    private Device _device;
    private int _mistakes;
    private TimeSpan _learningTimer;
    private DateTime _startTime;
    private DateTime _endTime;

    public SimulatorModel(
            IDeviceSpawner spawner)
    {
        _spawner = spawner;
    }
    
    public void OnSelectDevice(int num)
    {
        _startTime = DateTime.Now;
        _spawner.ShowDevice(num, out var simulatorScenarioConfig, out var device);
        _device = device;
        _device.OnClickElement -= OnClickElement;
        _device.OnClickElement += OnClickElement;
        _actions = new Queue<EntryAction>(simulatorScenarioConfig.ElementConfigs.Count);
        foreach (var elementConfig in simulatorScenarioConfig.ElementConfigs)
        {
            var action = new EntryAction(elementConfig.Element, elementConfig.TaskText);
            action.ElementsId[""] = true;
            _actions.Enqueue(action);
        }
        UpdateUi.Invoke(GetData(false, false));
    }

    private string GetTextMessage()
    {
        var textMessage = "";
        if(_actions.Count > 0)
            textMessage = _actions.Peek().TaskText;
        return textMessage;
    }

    public void Restart()
    {
        _actions.Clear();
        _device.ResetElements();
        _spawner.HideAll();
        _mistakes = 0;
    }

    private void OnClickElement(SimulatorElement element)
    {
        if(_actions.Count < 1) return;
        
        var currentElement = _actions.Peek();
        if (currentElement.ElementsId.ContainsKey(element.ElementId))
        {
            if (!currentElement.ElementsId[element.ElementId])
            {
                currentElement.ElementsId[element.ElementId] = true;
                element.PlayAnimation();
                var allComplete = currentElement.ElementsId.All(elements => elements.Value);

                //Все части текущего задания завершены, удаляем его из очереди
                if (allComplete)
                {
                    _actions.Dequeue();
                    if (_actions.Count < 1)
                    {
                        _endTime = DateTime.Now;
                        _learningTimer = _endTime - _startTime;
                        UpdateUi.Invoke(GetData(true, true));
                    }
                    else
                    {
                        //Пишем сообщение про следующее задание
                        UpdateUi.Invoke(GetData(false, false));
                    }
                }
            }
        }
        else
        {
            _mistakes++;
            //Пишем сообщение, что кликнули не то
            UpdateUi.Invoke(GetData(true, false));
        }

    }

    private DataForUi GetData(bool isShowPopup, bool isFinish)
    {
        return new DataForUi(GetTextMessage(), isShowPopup, isFinish, _mistakes, _learningTimer);
    } 
}