namespace SkillsSample.Scripts.Models
{
    public interface ISkillModel : IBaseModel
    {
        string Name { get; set; }
        int Cost { get; set; }
    }
}