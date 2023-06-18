using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Experience
{
    public Guid Id { get; set; }

    public string Company { get; set; } = null!;
    
    public string Title { get; set; } = null!;

    public int AnoIni { get; set; }

    public int AnoFim { get; set; }

    public virtual User? User { get; set; }
}
