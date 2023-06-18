namespace BusinessLogic.Entities;

public class Skill
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    
    public string Area { get; set; } = null!;
}