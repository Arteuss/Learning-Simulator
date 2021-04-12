
using System;

namespace ProjectUI
{
    public class UiController: IDisposable
    {
        private ISimulatorModel _simulatorModel;
        private UiView _uiView;
        
        public UiController(ISimulatorModel simulatorModel, UiView uiView)
        {
            _simulatorModel = simulatorModel;
            _uiView = uiView;
            _uiView.onSelect = _simulatorModel.OnSelectDevice;
            _uiView.onRestart = _simulatorModel.Restart;
            _simulatorModel.UpdateUi += _uiView.UpdateUi;
        }

        public void Dispose()
        {
            _simulatorModel.UpdateUi -= _uiView.UpdateUi;
        }
    }
}