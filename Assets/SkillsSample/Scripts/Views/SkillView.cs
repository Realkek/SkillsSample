using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace SkillsSample.Scripts.Views
{
    public class SkillView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI skillNameText;
        [SerializeField] private TextMeshProUGUI skillCost;
        public Button learnButton;
        public Button forgetButton;

        public event Action LearnButtonClicked;
        public event Action ForgetButtonClicked;

        private void Start()
        {
            learnButton.onClick.AddListener(() => LearnButtonClicked?.Invoke());
            forgetButton.onClick.AddListener(() => ForgetButtonClicked?.Invoke());
        }

        public void UpdateSkillUI(string skillName, int skillCost, bool isLearned)
        {
            this.skillCost.text = "Cost: " + skillCost;

            learnButton.interactable = !isLearned; // Если скилл уже изучен, кнопка "Изучить" неактивна
            forgetButton.interactable = isLearned; // Если скилл не изучен, кнопка "Забыть" неактивна
        }
    }
}