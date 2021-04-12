using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Ray _ray;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out var hitInfo))
            {
                var element = hitInfo.transform.GetComponentInParent<SimulatorElement>();
                if (element != null)
                {
                    element.OnClickElement();
                }
            }
        }
    }
}