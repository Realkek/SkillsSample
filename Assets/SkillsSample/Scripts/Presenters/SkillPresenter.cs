using SkillsSample.Scripts.Data.ScriptableObjects;
using SkillsSample.Scripts.Models;
using SkillsSample.Scripts.Views;

namespace SkillsSample.Scripts.Presenters
{
    public class SkillPresenter
    {
        private readonly SkillsSchemeModel _skillsSchemeModel;
        private readonly SkillStaticData _skillStaticData;
        private readonly PlayerSkillsModel _playerSkillsModel;
        private readonly SkillCellView _cellView;
        private ISkillModel _skill;

        public SkillPresenter(SkillsSchemeModel skillsSchemeModel, SkillCellView cellView,
            SkillStaticData skillStaticData, PlayerSkillsModel playerSkillsModel)
        {
            _skillsSchemeModel = skillsSchemeModel;
            _cellView = cellView;
            _skillStaticData = skillStaticData;
            _playerSkillsModel = playerSkillsModel;
            CreateSkillModel();
            ChooseBaseSkill();
            UpdateUi(_skill);
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
            if (_playerSkillsModel.SkillBaseId == _skillStaticData.CellId)
            {
                _playerSkillsModel.LearnSkill(_skill);
            }
        }

        private void Subscribe()
        {
            _cellView.LearnButtonClicked += OnLearnButtonClicked;
            _cellView.ForgetButtonClicked += OnForgetButtonClicked;
            _playerSkillsModel.AllSkillsAreReset += PlayerSkillsModelOnAllSkillsAreReset;
        }

        private void PlayerSkillsModelOnAllSkillsAreReset()
        {
            UpdateUi(_skill);
        }

        private void Unsubscribe()
        {
            _cellView.LearnButtonClicked -= OnLearnButtonClicked;
            _cellView.ForgetButtonClicked -= OnForgetButtonClicked;
            _playerSkillsModel.AllSkillsAreReset -= PlayerSkillsModelOnAllSkillsAreReset;
        }

        private void OnLearnButtonClicked()
        {
            if (SkillsSchemeModel.CheckPossibilityOfLearning(_skill, _playerSkillsModel.GetLearnedSkills()))
            {
                if (_playerSkillsModel.LearnSkill(_skill))
                {
                    UpdateUi(_skill);
                }
            }
        }

        private void OnForgetButtonClicked()
        {
            if (SkillsSchemeModel.CheckPossibilityOfForgetting(_skill, _playerSkillsModel.GetLearnedSkills()))
            {
                _playerSkillsModel.ForgetSkill(_skill);
                UpdateUi(_skill);
            }
        }

        private void UpdateUi(ISkillModel skill)
        {
            var isLearned = _playerSkillsModel.CheckSkillIsLearned(skill);
            var isBaseSkill = _playerSkillsModel.CheckSkillIsBase(skill);
            _cellView.UpdateSkillUI(_skillStaticData.SkillName, _skillStaticData.Cost, isLearned, isBaseSkill);
        }
    }
}