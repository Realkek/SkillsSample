using System.Collections.Generic;
using System.Linq;

namespace SkillsSample.Scripts.Models
{
    public class SkillsSchemeModel
    {
        private readonly Dictionary<int, string> _names;
        private readonly Dictionary<int, List<int>> _requiredNumbers;
        private readonly Dictionary<int, int> _costs;

        public void AddSkill(int skillId, string skillName, List<int> requiredSkills, int cost)
        {
            _names.Add(skillId, skillName);
            _requiredNumbers.Add(skillId, requiredSkills);
            _costs.Add(skillId, cost);
        }

        public bool CheckPossibilityOfLearning(int id, List<int> learnedSkillsNumbers)
        {
            _requiredNumbers.TryGetValue(id, out var requiredNumbers);
            return requiredNumbers != null && requiredNumbers.Any(learnedSkillsNumbers.Contains);
        }
    }
}