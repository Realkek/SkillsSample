using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SkillsSample.Scripts.Models
{
    public class PlayerSkillsModel : IBaseModel
    {
        private readonly List<ISkillModel> _learnedSkills = new();

        public int Id { get; set; }
        public int SkillBaseId { get; private set; }
        public int SkillPoints { get; private set; }

        public event Action<int> PointsChanged;
        public event Action AllSkillsAreReset;

        public PlayerSkillsModel(int startingSkillPoints, int skillBaseId)
        {
            SkillPoints = startingSkillPoints;
            SkillBaseId = skillBaseId;
        }

        public bool LearnSkill(ISkillModel skill)
        {
            if (SkillPoints < skill.Cost)
                return false;
            SkillPoints -= skill.Cost;
            _learnedSkills.Add(skill);
            PointsChanged?.Invoke(SkillPoints);
            return true;
        }

        public void ForgetSkill(ISkillModel skill)
        {
            SkillPoints += skill.Cost;
            _learnedSkills.Remove(skill);
            PointsChanged?.Invoke(SkillPoints);
        }

        public ICollection<ISkillModel> GetLearnedSkills()
        {
            return _learnedSkills;
        }

        public bool CheckSkillIsLearned(ISkillModel skillModel)
        {
            return _learnedSkills.Any(learnedSkill => learnedSkill == skillModel);
        }

        public bool CheckSkillIsBase(ISkillModel skillModel)
        {
            return skillModel.Id == SkillBaseId;
        }

        public void ResetAllSkills()
        {
            SkillPoints += GetCompensation();
            PointsChanged?.Invoke(SkillPoints);
            _learnedSkills.RemoveAll(learnedSkill => learnedSkill.Id != SkillBaseId);
            AllSkillsAreReset?.Invoke();
        }

        public void EarnPoints(int pointsCount)
        {
            SkillPoints += pointsCount;
            PointsChanged?.Invoke(SkillPoints);
        }

        private int GetCompensation()
        {
            return _learnedSkills.Where(learnedSkill => learnedSkill.Id != SkillBaseId)
                .Sum(learnedSkill => learnedSkill.Cost);
        }
    }
}