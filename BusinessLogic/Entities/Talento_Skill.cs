using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Talento_Skill
{
    public Guid Id { get; set; }
    
    public Guid IdSkill { get; set; }

    public string Name { get; set; } = null!;

    public Guid IdTalento { get; set; }
    
    public virtual Skill? Skill { get; set; }
    
    public virtual Talento? Talento { get; set; }
    public virtual ICollection<Talento> Talentos { get; set; } = new List<Talento>();
    
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}