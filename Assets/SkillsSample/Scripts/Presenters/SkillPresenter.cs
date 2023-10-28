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

        public SkillPresenter(SkillsSchemeModel skillsSchemeModel, SkillCellView cellView,
            SkillStaticData skillStaticData, PlayerModel playerModel)
        {
            _skillsSchemeModel = skillsSchemeModel;
            _cellView = cellView;
            _skillStaticData = skillStaticData;
            _playerModel = playerModel;
            CreateSkill();
            Subscribe();
        }

        private void CreateSkill()
        {
            var skill = new SkillModel(_skillStaticData.CellId, _skillStaticData.SkillName, _skillStaticData.Cost,
                _skillStaticData.RequiredSkillsNumbers);
            _skillsSchemeModel.AddSkill(skill);
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
            var skill = _skillsSchemeModel.GetSkillModel(_skillStaticData.CellId);
            if (SkillsSchemeModel.CheckPossibilityOfLearning(skill, _playerModel.GetLearnedSkills()))
            {
                _playerModel.LearnSkill(skill);
                // _cellView.UpdateSkillUI(_skillModel.SkillName, _skillModel.Cost, _skillModel.IsLearned);
            }
        }

        private void OnForgetButtonClicked()
        {
            /*_skillModel.ForgetSkill();
            _cellView.UpdateSkillUI(_skillModel.SkillName, _skillModel.Cost, _skillModel.IsLearned);*/
        }
    }
}