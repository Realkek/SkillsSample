using System.Collections.Generic;
using UnityEngine;

namespace SkillsSample.Scripts.Models
{
    public class SkillModel : ISkillModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public List<int> RequiredSkillsNumbers { get; set; }

        public SkillModel(int id, string name, int cost, List<int> requiredSkillsNumbers)
        {
            Id = id;
            Name = name;
            Cost = cost;
            RequiredSkillsNumbers = requiredSkillsNumbers;
        }
    }
}