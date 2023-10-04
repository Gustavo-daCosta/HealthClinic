using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

/// <summary>
/// Classe que representa a entidade Medico.
/// </summary>
public partial class Medico
{
    /// <summary>
    /// Obtém ou define o ID do médico.
    /// </summary>
    public Guid IdMedico { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Obtém ou define o ID do usuário associado ao médico.
    /// </summary>
    public Guid IdUsuario { get; set; }

    /// <summary>
    /// Obtém ou define o ID da especialidade do médico.
    /// </summary>
    public Guid IdEspecialidade { get; set; }

    /// <summary>
    /// Obtém ou define o ID da clínica onde o médico trabalha.
    /// </summary>
    public Guid IdClinica { get; set; }

    /// <summary>
    /// Obtém ou define o número de registro do médico (CRM).
    /// </summary>
    public string Crm { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a coleção de consultas associadas a este médico.
    /// </summary>
    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    /// <summary>
    /// Obtém ou define a navegação para a clínica associada a este médico.
    /// </summary>
    public virtual Clinica? IdClinicaNavigation { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a navegação para a especialidade associada a este médico.
    /// </summary>
    public virtual Especialidade? IdEspecialidadeNavigation { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a navegação para o usuário associado a este médico.
    /// </summary>
    public virtual Usuario? IdUsuarioNavigation { get; set; } = null!;
}
