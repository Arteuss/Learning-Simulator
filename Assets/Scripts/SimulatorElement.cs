using UnityEngine;

public class SimulatorElement : MonoBehaviour
{
    private Device _simulator;
    private bool _isEnable;
    [SerializeField] private AnimationClip _onClip;
    [SerializeField] private AnimationClip _offClip;
    [SerializeField] private string _elementId;

    public string ElementId => _elementId;

    private Animation AnimationE { get; set; }

    private void Start()
    {
        _isEnable = true;
        _simulator = GetComponentInParent<Device>();
        AnimationE = GetComponent<Animation>();
    }

    public void OnClickElement()
    {
        _simulator.SetElement(this);
    }

    public void PlayAnimation()
    {
        AnimationE.Play(_isEnable ? _offClip.name : _onClip.name);
        _isEnable = !_isEnable;
    }

    public void ResetElement()
    {
        AnimationE.Play(_onClip.name);
        _isEnable = true;
    }
}
