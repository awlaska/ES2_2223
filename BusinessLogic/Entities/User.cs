﻿using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    
    public int Role { get; set; }

    public string Email { get; set; } = null!;
    
    public string Password { get; set; } = null!;
    
    public string Country { get; set; } = null!;

    public double PrHora { get; set; }
    
    public Guid IdExperience { get; set; }

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
    
    public virtual ICollection<Talento> Talentos { get; set; } = new List<Talento>();
}
