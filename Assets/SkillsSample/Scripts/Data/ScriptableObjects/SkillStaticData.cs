using System.Collections.Generic;
using UnityEngine;

namespace SkillsSample.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SkillStaticData", menuName = "Static Data/SkillStaticData")]
    public class SkillStaticData : ScriptableObject
    {
        [SerializeField] private int _cellId;
        [SerializeField] private string _skillName;
        [SerializeField] private int _cost;
        [SerializeField] private List<int> _requiredSkillsNumbers;
        public int CellId => _cellId;
        public string SkillName => _skillName;
        public int Cost => _cost;
        public List<int> RequiredSkillsNumbers => _requiredSkillsNumbers;
    }
}