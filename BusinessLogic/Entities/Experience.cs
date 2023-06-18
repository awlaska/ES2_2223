using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Experience
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public int AnoIni { get; set; }

    public int AnoFim { get; set; }
    
    public Guid IdCompany { get; set; }

    public virtual User? User { get; set; }
    
    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
