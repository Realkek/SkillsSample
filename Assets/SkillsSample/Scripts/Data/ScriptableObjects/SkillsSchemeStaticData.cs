using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SkillsSample.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SkillsSchemeStaticData", menuName = "Static Data/SkillsSchemeStaticData")]
    public class SkillsSchemeStaticData : ScriptableObject
    {
        [SerializeField] private List<SkillStaticData> _skillsStaticData;
        [SerializeField] private int _skillBaseId;
       
        
        public List<SkillStaticData> SkillStaticData => _skillsStaticData;
        public int SkillBaseId => _skillBaseId;

        public SkillStaticData GetSkillStaticDataById(int id)
        {
            return _skillsStaticData.First(skillStaticData => skillStaticData.CellId == id);
        }
    }
}