using System.Collections.Generic;
using System.Linq;

namespace SkillsSample.Scripts.Models
{
    public class SkillModel
    {
        public int SkillID { get; private set; }
        public string SkillName { get; private set; }
        public int Cost { get; private set; }
        public List<SkillModel> PrerequisiteSkills { get; private set; }
        public bool IsLearned { get; private set; }
        
        public bool CheckLearnConditionsMet(int availableSkillPoints)
        {
            return !IsLearned && availableSkillPoints >= Cost && ArePrerequisitesLearned();
        }

        private bool ArePrerequisitesLearned()
        {
            return PrerequisiteSkills.All(prerequisiteSkill => prerequisiteSkill.IsLearned);
        }

        public void LearnSkill()
        {
            IsLearned = true;
        }

        public void ForgetSkill()
        {
            IsLearned = false;
        }
    }
}