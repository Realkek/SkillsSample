using SkillsSample.Scripts.Models;
using SkillsSample.Scripts.Views;

namespace SkillsSample.Scripts.Presenters
{
    public class SkillsPanelPresenter
    {
        private readonly SkillsPanelView _skillsPanelView;
        private readonly PlayerSkillsModel _playerSkillsModel;

        private const int TempEarnPointsCountByTestWorkSample = 1;

        public SkillsPanelPresenter(SkillsPanelView skillsPanelView, PlayerSkillsModel playerSkillsModel)
        {
            _skillsPanelView = skillsPanelView;
            _playerSkillsModel = playerSkillsModel;
            _skillsPanelView.UpdatePointsText(playerSkillsModel.SkillPoints);
            Subscribe();
        }

        private void Subscribe()
        {
            _playerSkillsModel.PointsChanged += PlayerSkillsModelOnPointsChanged;
            _skillsPanelView.ResetAllButtonClicked += SkillsPanelViewOnResetAllButtonClicked;
            _skillsPanelView.EarnButtonClicked += SkillsPanelViewOnEarnButtonClicked;
        }

        private void Unsubscribe()
        {
            _playerSkillsModel.PointsChanged -= PlayerSkillsModelOnPointsChanged;
            _skillsPanelView.ResetAllButtonClicked -= SkillsPanelViewOnResetAllButtonClicked;
            _skillsPanelView.EarnButtonClicked -= SkillsPanelViewOnEarnButtonClicked;
        }

        private void SkillsPanelViewOnResetAllButtonClicked()
        {
            _playerSkillsModel.ResetAllSkills();
        }

        private void SkillsPanelViewOnEarnButtonClicked()
        {
            _playerSkillsModel.EarnPoints(TempEarnPointsCountByTestWorkSample);
        }

        private void PlayerSkillsModelOnPointsChanged(int points)
        {
            _skillsPanelView.UpdatePointsText(points);
        }
    }
}