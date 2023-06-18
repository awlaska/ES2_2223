using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Experiencia
{
    public Guid Id { get; set; }

    public string Empresa { get; set; } = null!;
    
    public string Titulo { get; set; } = null!;

    public int AnoIni { get; set; }

    public int AnoFim { get; set; }

    public virtual User? User { get; set; }
}
