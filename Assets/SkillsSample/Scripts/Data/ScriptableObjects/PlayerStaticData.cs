using UnityEngine;

namespace SkillsSample.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerStaticData", menuName = "Static Data/PlayerStaticData")]
    public class PlayerStaticData : ScriptableObject
    {
        [SerializeField] private int _pointsNumber;
        [SerializeField] private int _skillBaseId;

        public int PointsNumber => _pointsNumber;
        public int SkillBaseId => _skillBaseId;
    }
}