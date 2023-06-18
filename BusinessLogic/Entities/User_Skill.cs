namespace BusinessLogic.Entities;

public class User_Skill
{
    public Guid Id { get; set; }
    public int AnoXp { get; set; }
    
    public Guid IdUser { get; set; }
    
    public Guid IdSkill { get; set; }
    
    public virtual User? User { get; set; }
    
    public virtual Skill? Skill { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
    
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}