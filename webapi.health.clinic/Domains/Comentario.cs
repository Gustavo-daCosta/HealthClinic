using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

public partial class Comentario
{
    public Guid IdComentario { get; set; }

    public Guid IdConsulta { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime Data { get; set; }

    public bool Exibe { get; set; }

    public virtual Consulta IdConsultaNavigation { get; set; } = null!;
}
