using System.Collections.Generic;

namespace SkillsSample.Scripts.Models
{
    public interface ISkillModel : IBaseModel
    {
        string Name { get; set; }
        int Cost { get; set; }
        List<int> RequiredSkillsNumbers { get; set; }
    }
}