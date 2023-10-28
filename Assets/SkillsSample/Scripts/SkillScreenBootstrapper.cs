using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private List<SkillCellView> _skillViews;

        private void Awake()
        {
            var skillsModel = new SkillsSchemeModel();
            foreach (var skillView in _skillViews)
            {
                var skillStaticData = _skillsSchemeStaticData.GetSkillStaticDataById(skillView.Id);
                var skillPresenter = new SkillPresenter(skillsModel, skillView, skillStaticData);
            }
        }
    }
}