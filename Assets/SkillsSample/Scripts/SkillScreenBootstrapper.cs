using System.Collections.Generic;
using SkillsSample.Scripts.Models;
using SkillsSample.Scripts.Presenters;
using SkillsSample.Scripts.Views;
using UnityEngine;

namespace SkillsSample.Scripts
{
    public class SkillScreenBootstrapper : MonoBehaviour
    {
        [SerializeField] private List<SkillCellView> _skillViews;

        private void Awake()
        {
            foreach (var skillView in _skillViews)
            {
                var skillModel = new SkillModel();
                var skillPresenter = new SkillPresenter(skillModel, skillView);
            }
        }
    }
}