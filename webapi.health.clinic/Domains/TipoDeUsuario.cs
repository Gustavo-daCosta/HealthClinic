using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

public partial class TipoDeUsuario
{
    public Guid IdTipoUsuario { get; set; }

    public string? TituloTipoUsuario { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
