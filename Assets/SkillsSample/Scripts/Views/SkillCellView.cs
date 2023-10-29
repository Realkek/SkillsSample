using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SkillsSample.Scripts.Views
{
    public class SkillCellView : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _cost;
        [SerializeField] private Image _image;

        private const string CostPrefix = "Cost: ";

        public int Id => _id;

        public Button learnButton;
        public Button forgetButton;

        public event Action LearnButtonClicked;
        public event Action ForgetButtonClicked;

        private void Start()
        {
            learnButton.onClick.AddListener(() => LearnButtonClicked?.Invoke());
            forgetButton.onClick.AddListener(() => ForgetButtonClicked?.Invoke());
        }

        public void UpdateSkillUI(string skillName, int skillCost, bool isLearned, bool isBaseSkill)
        {
            _name.text = skillName;
            if (!isBaseSkill)
            {
                _cost.text = CostPrefix + skillCost;
                forgetButton.gameObject.SetActive(isLearned);
            }

            learnButton.interactable = !isLearned;
            _image.color = isLearned ? Color.green : Color.blue;
        }
    }
}