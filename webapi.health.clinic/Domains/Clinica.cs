using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

public partial class Clinica
{
    public Guid IdClinica { get; set; } = Guid.NewGuid();

    public string RazaoSocial { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public TimeOnly HoraAbertura { get; set; }

    public TimeOnly HoraEncerramento { get; set; }

    public virtual ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
