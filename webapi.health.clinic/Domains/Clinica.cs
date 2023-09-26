using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

public partial class Clinica
{
    public Guid IdClinica { get; set; }

    public string RazaoSocial { get; set; } = null!;
                                                    
    public string Endereco { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
