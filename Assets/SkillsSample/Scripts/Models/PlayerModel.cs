using System.Collections.Generic;

namespace SkillsSample.Scripts.Models
{
    public class PlayerModel : IBaseModel
    {
        public int Id { get; set; }
        private int _points { get; set; }

        private readonly List<ISkillModel> _learnedSkills;
        private int _skillBaseId { get; set; }

        public PlayerModel(int startingPoints)
        {
            _points = startingPoints;
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
    }
}