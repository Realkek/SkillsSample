using System.Collections.Generic;

namespace SkillsSample.Scripts.Models
{
    public class PlayerModel
    {
        public int Points { get; private set; }
        public List<SkillModel> Skills { get; private set; }

        public PlayerModel(int startingPoints, List<SkillModel> startingSkills)
        {
            Points = startingPoints;
            Skills = startingSkills;
        }
    }
}