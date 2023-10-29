using System.Collections.Generic;
using System.Linq;

namespace SkillsSample.Scripts.Models
{
    public class SkillsSchemeModel : IBaseModel
    {
        public int Id { get; set; }

        private const int NoCostNumber = 0;
        private readonly Dictionary<int, ISkillModel> _skills = new();

        public void AddSkill(ISkillModel skillModel)
        {
            _skills.Add(skillModel.Id, skillModel);
        }

        public static bool CheckPossibilityOfLearning(ISkillModel skillModel, ICollection<ISkillModel> learnedSkills)
        {
            return skillModel.RequiredSkillsNumbers.Any(requiredNumber =>
                learnedSkills.Any(ls => ls.Id == requiredNumber));
        }


        public static bool CheckPossibilityOfForgetting(ISkillModel skillModel, ICollection<ISkillModel> learnedSkills)
        {
            var dependentSkills = learnedSkills.Where(learnedSkill =>
                learnedSkill.RequiredSkillsNumbers.Contains(skillModel.Id));

            return dependentSkills.All(dependentSkill =>
            {
                var alternateLearnedSkills = dependentSkill.RequiredSkillsNumbers
                    .Except(new[] {skillModel.Id});

                return learnedSkills.Any(learnedSkill =>
                    alternateLearnedSkills.Contains(learnedSkill.Id));
            });
        }

        public ISkillModel GetSkillModel(int id)
        {
            _skills.TryGetValue(id, out var skillModel);
            return skillModel;
        }
    }
}