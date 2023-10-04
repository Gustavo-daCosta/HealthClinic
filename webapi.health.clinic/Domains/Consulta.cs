using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

public partial class Consulta
{
    public Guid IdConsulta { get; set; } = Guid.NewGuid();

    public Guid IdClinica { get; set; }

    public Guid IdMedico { get; set; }

    public Guid IdPaciente { get; set; }

    public DateTime Data { get; set; }

    public bool Situacao { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Clinica? IdClinicaNavigation { get; set; } = null!;

    public virtual Medico? IdMedicoNavigation { get; set; } = null!;

    public virtual Paciente? IdPacienteNavigation { get; set; } = null!;

    public virtual ICollection<Prontuario> Prontuarios { get; set; } = new List<Prontuario>();
}
