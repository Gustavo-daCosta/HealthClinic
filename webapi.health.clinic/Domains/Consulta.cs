using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

/// <summary>
/// Classe que representa a entidade Consulta.
/// </summary>
public partial class Consulta
{
    /// <summary>
    /// Obtém ou define o identificador único da consulta.
    /// </summary>
    public Guid IdConsulta { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Obtém ou define o identificador único da clínica associada à consulta.
    /// </summary>
    public Guid IdClinica { get; set; }

    /// <summary>
    /// Obtém ou define o identificador único do médico associado à consulta.
    /// </summary>
    public Guid IdMedico { get; set; }

    /// <summary>
    /// Obtém ou define o identificador único do paciente associado à consulta.
    /// </summary>
    public Guid IdPaciente { get; set; }

    /// <summary>
    /// Obtém ou define a data da consulta.
    /// </summary>
    public DateTime Data { get; set; }

    /// <summary>
    /// Obtém ou define a situação da consulta (Ativa ou Inativa).
    /// </summary>
    public bool Situacao { get; set; }

    /// <summary>
    /// Obtém ou define a coleção de comentários associados à consulta.
    /// </summary>
    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    /// <summary>
    /// Obtém ou define a clínica relacionada à consulta.
    /// </summary>
    public virtual Clinica? IdClinicaNavigation { get; set; } = null!;

    /// <summary>
    /// Obtém ou define o médico relacionado à consulta.
    /// </summary>
    public virtual Medico? IdMedicoNavigation { get; set; } = null!;

    /// <summary>
    /// Obtém ou define o paciente relacionado à consulta.
    /// </summary>
    public virtual Paciente? IdPacienteNavigation { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a coleção de prontuários associados à consulta.
    /// </summary>
    public virtual ICollection<Prontuario> Prontuarios { get; set; } = new List<Prontuario>();
}
