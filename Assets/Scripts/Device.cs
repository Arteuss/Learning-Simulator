using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Device : MonoBehaviour
{
    public event Action<SimulatorElement> OnClickElement;
    private List<SimulatorElement> _elements = new List<SimulatorElement>();
    
    private void Awake()
    {
        _elements = GetComponentsInChildren<SimulatorElement>().ToList();
    }
    
    public void SetElement(SimulatorElement element)
    {
        OnClickElement.Invoke(element);
    }

    public void ResetElements()
    {
        foreach (var simulatorElement in _elements)
        {
            simulatorElement.ResetElement();
        }
    }
}