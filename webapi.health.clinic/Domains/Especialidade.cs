using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

public partial class Especialidade
{
    public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

    public string TituloEspecialidade { get; set; } = null!;

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
