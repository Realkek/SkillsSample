using System.Collections.Generic;

namespace SkillsSample.Scripts.Models
{
    public class PlayerModel : IBaseModel
    {
        public int Id { get; set; }

        private int _points;
        private int _skillBaseId;

        private readonly List<ISkillModel> _learnedSkills = new();

        public PlayerModel(int startingPoints, int skillBaseId)
        {
            _points = startingPoints;
            _skillBaseId = skillBaseId;
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