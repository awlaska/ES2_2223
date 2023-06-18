using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Company
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}