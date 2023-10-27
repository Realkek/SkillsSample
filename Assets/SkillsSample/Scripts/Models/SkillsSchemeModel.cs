using System.Collections.Generic;
using UnityEngine;

namespace SkillsSample.Scripts.Models
{
    public class SkillsSchemeModel
    {
        private List<SkillModel> _skillModels { get; set; } = new List<SkillModel>();

        public SkillsSchemeModel(List<SkillModel> skillModels)
        {
            _skillModels = _skillModels;
        }
    }
}