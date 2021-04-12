using System.Collections.Generic;

public class EntryAction
{
    public Dictionary<string, bool> ElementsId { get;}
    public string TaskText { get; }

    public EntryAction(List<SimulatorElement> elements, string taskText)
    {
        ElementsId = new Dictionary<string, bool>();
        foreach (var element in elements)
        {
            ElementsId[element.ElementId] = false;
        }
        TaskText = taskText;
    }
}