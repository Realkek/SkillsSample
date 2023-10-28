using UnityEngine;

namespace SkillsSample.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SkillsSchemeStaticData", menuName = "Static Data/SkillsSchemeStaticData")]
    public class PlayerStaticData : ScriptableObject
    {
        [SerializeField] private int _pointsNumber;

        public int PointsNumber => _pointsNumber;
    }
}