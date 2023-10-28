using SkillsSample.Scripts.Data.ScriptableObjects;
using SkillsSample.Scripts.Models;
using SkillsSample.Scripts.Views;

namespace SkillsSample.Scripts.Presenters
{
    public class SkillPresenter
    {
        private readonly SkillsSchemeModel _skillsSchemeModel;
        private readonly SkillStaticData _skillStaticData;
        private PlayerModel _playerModel;
        private readonly SkillCellView _cellView;

        public SkillPresenter(SkillsSchemeModel skillsSchemeModel, SkillCellView cellView,
            SkillStaticData skillStaticData)
        {
            _skillsSchemeModel = skillsSchemeModel;
            _cellView = cellView;
            _skillStaticData = skillStaticData;

            Subscribe();
        }

        private void FillSkill()
        {
            _skillsSchemeModel.AddSkill(_skillStaticData.CellId, _skillStaticData.SkillName,
                _skillStaticData.RequiredSkillsNumbers, _skillStaticData.Cost);
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
            /*if (!_skillModel.CheckLearnConditionsMet(_playerModel.Points)) return;
            _skillModel.LearnSkill();
            _cellView.UpdateSkillUI(_skillModel.SkillName, _skillModel.Cost, _skillModel.IsLearned);*/
        }

        private void OnForgetButtonClicked()
        {
            /*_skillModel.ForgetSkill();
            _cellView.UpdateSkillUI(_skillModel.SkillName, _skillModel.Cost, _skillModel.IsLearned);*/
        }
    }
}