using System.Collections.Generic;

namespace SkillsSample.Scripts.Models
{
    public class PlayerModel : IBaseModel
    {
        private int _points;

        private readonly List<ISkillModel> _learnedSkills = new();

        public int Id { get; set; }
        public int SkillBaseId { get; set; }

        public PlayerModel(int startingPoints, int skillBaseId)
        {
            _points = startingPoints;
            SkillBaseId = skillBaseId;
        }

        public bool LearnSkill(ISkillModel skill)
        {
            if (_points < skill.Cost)
                return false;
            _learnedSkills.Add(skill);
            return true;
        }

        public void ForgetSkill(ISkillModel skill)
        {
            _points += skill.Cost;
            _learnedSkills.Remove(skill);
        }

        public IEnumerable<ISkillModel> GetLearnedSkills()
        {
            return _learnedSkills;
        }
    }
}