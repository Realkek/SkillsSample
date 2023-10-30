using System.Collections.Generic;
using SkillsSample.Scripts.Data.ScriptableObjects;
using SkillsSample.Scripts.Models;
using SkillsSample.Scripts.Presenters;
using SkillsSample.Scripts.Views;
using UnityEngine;

namespace SkillsSample.Scripts
{
    public class SkillScreenBootstrapper : MonoBehaviour
    {
        [SerializeField] private SkillsSchemeStaticData _skillsSchemeStaticData;
        [SerializeField] private PlayerStaticData _playerStaticData;
        [SerializeField] private List<SkillCellView> _skillViews;
        [SerializeField] private SkillsPanelView _skillsPanelView;

        private void Awake()
        {
            var skillsModel = new SkillsSchemeModel();
            var playerModel = new PlayerSkillsModel(_playerStaticData.PointsNumber, _playerStaticData.SkillBaseId);
            foreach (var skillView in _skillViews)
            {
                var skillStaticData = _skillsSchemeStaticData.GetSkillStaticDataById(skillView.Id);
                var skillPresenter = new SkillPresenter(skillsModel, skillView, skillStaticData, playerModel);
            }

            var skillsPanelPresenter = new SkillsPanelPresenter(_skillsPanelView, playerModel);
        }
    }
}