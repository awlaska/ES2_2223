using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
    
    public string Password { get; set; } = null!;
    
    public string Country { get; set; } = null!;

    public float PrHora { get; set; }

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
}
