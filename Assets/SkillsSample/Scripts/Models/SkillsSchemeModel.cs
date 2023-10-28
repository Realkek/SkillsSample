using System.Collections.Generic;
using System.Linq;

namespace SkillsSample.Scripts.Models
{
    public class SkillsSchemeModel : IBaseModel
    {
        public int Id { get; set; }

        private const int NoCostNumber = 0;
        private readonly Dictionary<int, ISkillModel> _skills;
        private readonly Dictionary<int, List<ISkillModel>> _requiredSkills;

        public void AddSkill(int skillId, string skillName, List<int> requiredSkills, int cost)
        {
            _skills.Add(skillId, new SkillModel(skillId, skillName, cost));
        }

        private bool CheckPossibilityOfLearning(int id, ICollection<ISkillModel> learnedSkills)
        {
            _requiredSkills.TryGetValue(id, out var requiredSkills);
            return requiredSkills != null && requiredSkills.Any(learnedSkills.Contains);
        }

        private bool CheckPossibilityOfForgetting(int id, IEnumerable<ISkillModel> learnedSkills)
        {
            return learnedSkills.Select(learnedSkill =>
                    learnedSkill.Id != id & _requiredSkills.Any(requiredSkills =>
                        requiredSkills.Value.Contains(learnedSkill)))
                .FirstOrDefault();
        }
    }
}