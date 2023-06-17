using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Experiencia
{
    public Guid Id { get; set; }

    public string empresa { get; set; } = null!;
    
    public string titulo { get; set; } = null!;

    public int ano_ini { get; set; }

    public int ano_fim { get; set; }

    public virtual User? User { get; set; }
}
