using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Talento
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid IdCategoria { get; set; }

    public virtual ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
}