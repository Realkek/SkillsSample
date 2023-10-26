namespace SkillsSample.Scripts.Models
{
    [System.Serializable]
    public class SkillModel
    {
        public int SkillID { get; private set; }
        public string SkillName { get; private set; }
        public int Cost { get; private set; }
        public bool IsLearned { get; private set; }
        public int[] ConnectedSkills { get; private set; }

        public SkillModel(int id, string name, int cost, int[] connectedSkills)
        {
            SkillID = id;
            SkillName = name;
            this.Cost = cost;
            IsLearned = false;
            this.ConnectedSkills = connectedSkills;
        }
    }
}