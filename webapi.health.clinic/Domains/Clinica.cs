using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

/// <summary>
/// Classe que representa a entidade Clinica.
/// </summary>
public partial class Clinica
{
    /// <summary>
    /// Obtém ou define o identificador único da clínica.
    /// </summary>
    public Guid IdClinica { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Obtém ou define a razão social da clínica.
    /// </summary>
    public string RazaoSocial { get; set; } = null!;

    /// <summary>
    /// Obtém ou define o endereço da clínica.
    /// </summary>
    public string Endereco { get; set; } = null!;

    /// <summary>
    /// Obtém ou define o CNPJ da clínica.
    /// </summary>
    public string Cnpj { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a hora de abertura da clínica.
    /// </summary>
    public TimeOnly HoraAbertura { get; set; }

    /// <summary>
    /// Obtém ou define a hora de encerramento da clínica.
    /// </summary>
    public TimeOnly HoraEncerramento { get; set; }

    /// <summary>
    /// Obtém ou define a lista de consultas associadas à clínica.
    /// </summary>
    public virtual ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();

    /// <summary>
    /// Obtém ou define a lista de médicos associados à clínica.
    /// </summary>
    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
