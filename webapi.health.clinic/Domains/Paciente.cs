using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

public partial class Paciente
{
    public Guid IdPaciente { get; set; }

    public Guid IdUsuario { get; set; }

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
