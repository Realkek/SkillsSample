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
        [SerializeField] private Button _earnButton;
        public event Action ResetAllButtonClicked;
        public event Action EarnButtonClicked;

        private void Awake()
        {
            _resetAllButton.onClick.AddListener(() => ResetAllButtonClicked?.Invoke());
            _earnButton.onClick.AddListener(() => EarnButtonClicked?.Invoke());
        }

        public void UpdatePointsText(int pointsValue)
        {
            _points.text = $"Очки: {pointsValue}";
        }

        private void OnDestroy()
        {
            _resetAllButton.onClick.RemoveAllListeners();
            _earnButton.onClick.RemoveAllListeners();
        }
    }
}