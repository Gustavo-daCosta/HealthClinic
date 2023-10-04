using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

/// <summary>
/// Classe que representa a entidade Especialidade.
/// </summary>
public partial class Especialidade
{
    /// <summary>
    /// Obtém ou define o identificador único da especialidade.
    /// </summary>
    public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Obtém ou define o título da especialidade.
    /// </summary>
    public string TituloEspecialidade { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a lista de médicos associados a esta especialidade.
    /// </summary>
    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
