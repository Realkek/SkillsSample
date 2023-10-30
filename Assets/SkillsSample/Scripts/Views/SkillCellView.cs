using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace SkillsSample.Scripts.Views
{
    public class SkillCellView : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _cost;
        [SerializeField] private Image _image;
        [SerializeField] private Button _learnButton;
        [SerializeField] private Button _forgetButton;

        private const string CostPrefix = "Cost: ";

        public int Id => _id;
        
        public event Action LearnButtonClicked;
        public event Action ForgetButtonClicked;

        private void Start()
        {
            _learnButton.onClick.AddListener(() => LearnButtonClicked?.Invoke());
            _forgetButton.onClick.AddListener(() => ForgetButtonClicked?.Invoke());
        }

        public void UpdateSkillUI(string skillName, int skillCost, bool isLearned, bool isBaseSkill)
        {
            _name.text = skillName;
            if (!isBaseSkill)
            {
                _cost.text = CostPrefix + skillCost;
                _forgetButton.gameObject.SetActive(isLearned);
            }

            _learnButton.interactable = !isLearned;
            _image.color = isLearned ? Color.green : Color.blue;
        }

        private void OnDestroy()
        {
            _learnButton.onClick.RemoveAllListeners();
            _forgetButton.onClick.RemoveAllListeners();
        }
    }
}