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

        public bool CheckPossibilityOfForgetting(IBaseModel skillModel, IEnumerable<ISkillModel> learnedSkills)
        {
            return !learnedSkills.Where(learnedSkill => learnedSkill.Id != skillModel.Id).Any(learnedSkill =>
                learnedSkill.RequiredSkillsNumbers.Contains(skillModel.Id));
        }

        public ISkillModel GetSkillModel(int id)
        {
            _skills.TryGetValue(id, out var skillModel);
            return skillModel;
        }
    }
}