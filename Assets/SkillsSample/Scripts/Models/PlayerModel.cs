using System.Collections.Generic;

namespace SkillsSample.Scripts.Models
{
    public abstract class PlayerModel
    {
        private readonly List<int> _learnedSkillsNumbers;

        public int Points { get; private set; }

        public PlayerModel(int startingPoints, List<int> baseLearnedSkillsNumbers)
        {
            Points = startingPoints;
            _learnedSkillsNumbers = baseLearnedSkillsNumbers;
        }

        public void AddLearnedSkillNumber(int skillNumber)
        {
            _learnedSkillsNumbers.Add(skillNumber);
        }
    }
}