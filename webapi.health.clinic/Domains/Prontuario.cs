using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

public partial class Prontuario
{
    public Guid IdProntuario { get; set; } = Guid.NewGuid();

    public Guid IdConsulta { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public virtual Consulta IdConsultaNavigation { get; set; } = null!;
}
