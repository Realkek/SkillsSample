using SkillsSample.Scripts.Models;
using SkillsSample.Scripts.Views;
using UnityEngine;

namespace SkillsSample.Scripts.Presenters
{
    public class SkillPresenter
    {
        private readonly SkillModel _model;
        private PlayerModel _playerModel;
        private readonly SkillCellView _cellView;

        public SkillPresenter(SkillModel model, SkillCellView cellView)
        {
            _model = model;
            _cellView = cellView;

            cellView.LearnButtonClicked += OnLearnButtonClicked;
            cellView.ForgetButtonClicked += OnForgetButtonClicked;
        }

        private void OnLearnButtonClicked()
        {
            if (!_model.CheckLearnConditionsMet(_playerModel.Points)) return;
            _model.LearnSkill();
            _cellView.UpdateSkillUI(_model.SkillName, _model.Cost, _model.IsLearned);
        }

        private void OnForgetButtonClicked()
        {
            _model.ForgetSkill();
            _cellView.UpdateSkillUI(_model.SkillName, _model.Cost, _model.IsLearned);
        }
    }
}