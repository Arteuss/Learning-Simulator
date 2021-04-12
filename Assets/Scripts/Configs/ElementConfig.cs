using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "SimulatorCreator/ElementConfig", fileName = "ElementConfig")]
public class ElementConfig : ScriptableObject
{
    public List<SimulatorElement> Element;
    public string TaskText;
}