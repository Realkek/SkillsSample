using System.Collections.Generic;

namespace SkillsSample.Scripts.Models
{
    [System.Serializable]
    public class SkillModel
    {
        public int SkillID { get; private set; }
        public string SkillName { get; private set; }
        public int Cost { get; private set; }
        public List<int> PrerequisiteSkills { get; private set; }
        public bool IsLearned { get; private set; }

        public SkillModel(int skillID, string skillName, int cost, List<int> prerequisites)
        {
            SkillID = skillID;
            SkillName = skillName;
            Cost = cost;
            PrerequisiteSkills = prerequisites;
            IsLearned = false;
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