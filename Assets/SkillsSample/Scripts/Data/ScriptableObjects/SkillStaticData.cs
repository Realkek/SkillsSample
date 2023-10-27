using SkillsSample.Scripts.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace SkillsSample.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SkillStaticData", menuName = "Static Data/SkillStaticData")]
    public class SkillStaticData : ScriptableObject
    {
        public int CellId { get; private set; }
        public string SkillName { get; private set; }
        public int Cost { get; private set; }
    }
}