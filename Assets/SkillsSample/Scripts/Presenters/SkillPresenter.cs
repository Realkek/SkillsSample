using SkillsSample.Scripts.Data.ScriptableObjects;
using SkillsSample.Scripts.Models;
using SkillsSample.Scripts.Views;
using Unity.VisualScripting;

namespace SkillsSample.Scripts.Presenters
{
    public class SkillPresenter
    {
        private readonly SkillsSchemeModel _skillsSchemeModel;
        private readonly SkillStaticData _skillStaticData;
        private PlayerModel _playerModel;
        private readonly SkillCellView _cellView;
        private ISkillModel _skill;

        public SkillPresenter(SkillsSchemeModel skillsSchemeModel, SkillCellView cellView,
            SkillStaticData skillStaticData, PlayerModel playerModel)
        {
            _skillsSchemeModel = skillsSchemeModel;
            _cellView = cellView;
            _skillStaticData = skillStaticData;
            _playerModel = playerModel;
            CreateSkillModel();
            _cellView.UpdateSkillUI(_skillStaticData.SkillName, _skillStaticData.Cost, false);
            Subscribe();
        }

        private void CreateSkillModel()
        {
            _skill = new SkillModel(_skillStaticData.CellId, _skillStaticData.SkillName, _skillStaticData.Cost,
                _skillStaticData.RequiredSkillsNumbers);
            _skillsSchemeModel.AddSkill(_skill);
        }

        private void Subscribe()
        {
            _cellView.LearnButtonClicked += OnLearnButtonClicked;
            _cellView.ForgetButtonClicked += OnForgetButtonClicked;
        }

        private void Unsubscribe()
        {
            _cellView.LearnButtonClicked -= OnLearnButtonClicked;
            _cellView.ForgetButtonClicked -= OnForgetButtonClicked;
        }

        private void OnLearnButtonClicked()
        {
            if (SkillsSchemeModel.CheckPossibilityOfLearning(_skill, _playerModel.GetLearnedSkills()))
            {
                if (_playerModel.LearnSkill(_skill))
                    _cellView.UpdateSkillUI(_skillStaticData.SkillName, _skillStaticData.Cost, true);
            }
        }

        private void OnForgetButtonClicked()
        {
            if (_skillsSchemeModel.CheckPossibilityOfForgetting(_skill, _playerModel.GetLearnedSkills()))
            {
                _playerModel.ForgetSkill(_skill);
                _cellView.UpdateSkillUI(_skill.Name, _skill.Cost, false);
            }
        }
    }
}