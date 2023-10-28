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

        public static bool CheckPossibilityOfLearning(ISkillModel skillModel, IEnumerable<ISkillModel> learnedSkills)
        {
            foreach (var learnedSkill in learnedSkills)
                return (skillModel != null && skillModel.RequiredSkillsNumbers.Contains(learnedSkill.Id));
            
            return true;
        }

        private bool CheckPossibilityOfForgetting(int id, IEnumerable<ISkillModel> learnedSkills)
        {
            /*return learnedSkills.Select(learnedSkill =>
                    learnedSkill.Id != id & _requiredSkillsNumbers.Any(requiredSkills =>
                        requiredSkills.Value.Contains(learnedSkill)))
                .FirstOrDefault();*/
            return false;
        }

        public ISkillModel GetSkillModel(int id)
        {
            _skills.TryGetValue(id, out var skillModel);
            return skillModel;
        }
    }
}