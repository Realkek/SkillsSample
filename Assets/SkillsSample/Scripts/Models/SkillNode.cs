using System.Collections.Generic;
using UnityEngine;

namespace SkillsSample.Scripts.Models
{
    [System.Serializable]
    public class SkillNode
    {
        public int skillID;
        public string skillName;
        public int cost;
        public bool isBaseSkill;
        public List<SkillNode> prerequisites;

        public SkillNode(int id, string name, int cost, bool isBase)
        {
            skillID = id;
            skillName = name;
            this.cost = cost;
            isBaseSkill = isBase;
            prerequisites = new List<SkillNode>();
        }

        public void AddPrerequisite(SkillNode skillNode)
        {
            prerequisites.Add(skillNode);
        }
    }
}