using System.Linq;
using SkillsSample.Scripts.Data.ScriptableObjects;
using SkillsSample.Scripts.Models;
using SkillsSample.Scripts.Views;

namespace SkillsSample.Scripts.Presenters
{
    public class SkillPresenter
    {
        private readonly SkillsSchemeModel _skillsSchemeModel;
        private readonly SkillStaticData _skillStaticData;
        private readonly PlayerModel _playerModel;
        private readonly SkillCellView _cellView;
        private ISkillModel _skill;
        private bool _isLearned;
        private bool _isBaseSkill;

        public SkillPresenter(SkillsSchemeModel skillsSchemeModel, SkillCellView cellView,
            SkillStaticData skillStaticData, PlayerModel playerModel)
        {
            _skillsSchemeModel = skillsSchemeModel;
            _cellView = cellView;
            _skillStaticData = skillStaticData;
            _playerModel = playerModel;
            CreateSkillModel();
            ChooseBaseSkill();
            UpdateUi();
            Subscribe();
        }

        private void CreateSkillModel()
        {
            _skill = new SkillModel(_skillStaticData.CellId, _skillStaticData.SkillName, _skillStaticData.Cost,
                _skillStaticData.RequiredSkillsNumbers);
            _skillsSchemeModel.AddSkill(_skill);
        }

        private void ChooseBaseSkill()
        {
            if (_playerModel.SkillBaseId == _skillStaticData.CellId)
            {
                _playerModel.LearnSkill(_skill);
                _isLearned = true;
                _isBaseSkill = true;
            }
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
            if (SkillsSchemeModel.CheckPossibilityOfLearning(_skill, _playerModel.GetLearnedSkills().ToList()))
            {
                if (_playerModel.LearnSkill(_skill))
                {
                    _isLearned = true;
                    UpdateUi();
                }
            }
        }

        private void OnForgetButtonClicked()
        {
            if (_skillsSchemeModel.CheckPossibilityOfForgetting(_skill, _playerModel.GetLearnedSkills()))
            {
                _playerModel.ForgetSkill(_skill);
                UpdateUi();
            }
        }

        private void UpdateUi()
        {
            _cellView.UpdateSkillUI(_skillStaticData.SkillName, _skillStaticData.Cost, _isLearned, _isBaseSkill);
        }
    }
}