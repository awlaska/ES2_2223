using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public class Categoria
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}