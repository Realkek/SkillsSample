using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SkillsSample.Scripts.Views
{
    public class SkillsPanelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _points;
        [SerializeField] private Button _resetAllButton;

        public event Action ResetAllButtonClicked;

        private void Start()
        {
            _resetAllButton.onClick.AddListener(() => ResetAllButtonClicked?.Invoke());
        }

        public void UpdatePointsText(int pointsValue)
        {
            _points.text = $"Очки: {pointsValue}";
        }

        private void OnDestroy()
        {
            _resetAllButton.onClick.RemoveAllListeners();
        }
    }
}