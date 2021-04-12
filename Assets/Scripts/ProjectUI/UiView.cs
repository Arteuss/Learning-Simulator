using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectUI
{
    public class UiView : MonoBehaviour
    {
        #region Variables
        [SerializeField] private List<Button> _startButtons;
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private GameObject _taskPanel;
        [SerializeField] private GameObject _endPanel;
        [SerializeField] private GameObject _resultPanel;
        [SerializeField] private TextMeshProUGUI _taskText;
        [SerializeField] private TextMeshProUGUI _endTitleText;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private TextMeshProUGUI _mistakesText;
        [SerializeField] private TextMeshProUGUI _learningTimeText;
        private CanvasGroup _cgStartPanel;
        private CanvasGroup _cgTaskPanel;
        private CanvasGroup _cgEndPanel;
        private const string EndTitleWrong = "Вы допустили ошибку!";
        private const string EndTitleComplete = "Обучение пройдено!";
        private const string Mistakes = "Kоличество ошибок - ";
        private const string LearningTime = "Время обучения - ";
        #endregion

        public Action<int> onSelect;
        public Action onRestart;

        private void Start()
        {
            _cgStartPanel = _startPanel.GetComponent<CanvasGroup>();
            _cgTaskPanel = _taskPanel.GetComponent<CanvasGroup>();
            _cgEndPanel = _endPanel.GetComponent<CanvasGroup>();
            for (int i = 0; i < _startButtons.Count; i++)
            {
                var num = i;
                var button = _startButtons[i];
                button.onClick.AddListener( () => OnButtonClick(num));
            }
            _continueButton.onClick.AddListener(OnContinueClick);
            _restartButton.onClick.AddListener(OnRestartClick);
            HidePanel(_cgTaskPanel);
            HidePanel(_cgEndPanel);
            ShowPanel(_cgStartPanel);
        }

        public void UpdateUi(DataForUi data)
        {
            _taskText.text = data.Message;
            if (!data.IsShowPopup) return;
            if (data.IsFinish) ShowEndPanel(data.Mistakes, data.LearningTime);
            else ShowWrongPanel();
        }

        private void OnButtonClick(int num)
        {
            onSelect(num);
            HidePanel(_cgStartPanel);
            ShowPanel(_cgTaskPanel);
        }

        private void OnRestartClick()
        {
            HidePanel(_cgEndPanel);
            HidePanel(_cgTaskPanel);
            ShowPanel(_cgStartPanel);
            onRestart.Invoke();
        }
        
        private void OnContinueClick()
        {
            HidePanel(_cgEndPanel);
        }

        private void HidePanel(CanvasGroup panel)
        {
            DOTween.To(()=> panel.alpha, x=> panel.alpha = x, 0, 0.5f);
            panel.blocksRaycasts = false;
        }
        
        private void ShowPanel(CanvasGroup panel)
        {
            DOTween.To(()=> panel.alpha, x=> panel.alpha = x, 1, 0.5f);
            panel.blocksRaycasts = true;
        }

        private void ShowEndPanel(int mistakeCount, TimeSpan timer)
        {
            _endTitleText.text = EndTitleComplete;
            _continueButton.gameObject.SetActive(false);
            _resultPanel.SetActive(true);
            _mistakesText.text = $"{Mistakes}{mistakeCount}";
            _learningTimeText.text = $"{LearningTime} {timer.Minutes} м. {timer.Seconds} с.";
            ShowPanel(_cgEndPanel);
            HidePanel(_cgTaskPanel);
        }
        
        private void ShowWrongPanel()
        {
            _endTitleText.text = EndTitleWrong;
            _continueButton.gameObject.SetActive(true);
            _resultPanel.SetActive(false);
            ShowPanel(_cgEndPanel);
        }
    }
}