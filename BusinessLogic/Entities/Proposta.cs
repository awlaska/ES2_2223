using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Proposta
{
    public Guid Id { get; set; }

    public string Descricao { get; set; } = null!;

    public Guid IdCompany { get; set; }
    
    public Guid IdUser { get; set; }
    
    public Guid IdCategoria { get; set; }

    public virtual ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
    
    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
    
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}