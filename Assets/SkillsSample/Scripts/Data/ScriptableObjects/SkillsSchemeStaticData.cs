using System.Collections.Generic;
using UnityEngine;

namespace SkillsSample.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SkillsSchemeStaticData", menuName = "Static Data/SkillsSchemeStaticData")]
    public class SkillsSchemeStaticData : ScriptableObject
    {
        [SerializeField] private List<SkillStaticData> _skillStaticData;
        [SerializeField] private int _skillBaseId;

        public List<SkillStaticData> SkillStaticData => _skillStaticData;
        public int SkillBaseId => _skillBaseId;
    }
}