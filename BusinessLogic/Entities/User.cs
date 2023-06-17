using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string name { get; set; } = null!;

    public string email { get; set; } = null!;
    
    public string password { get; set; } = null!;
    
    public string pais { get; set; } = null!;

    public float pr_hora { get; set; }

    public virtual ICollection<Experiencia> Experiencias { get; set; } = new List<Experiencia>();
}
