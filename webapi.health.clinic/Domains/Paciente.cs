using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

/// <summary>
/// Classe que representa a entidade Paciente.
/// </summary>
public partial class Paciente
{
    /// <summary>
    /// Obtém ou define o identificador único do paciente.
    /// </summary>
    public Guid IdPaciente { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Obtém ou define o identificador único do usuário associado ao paciente.
    /// </summary>
    public Guid IdUsuario { get; set; }

    /// <summary>
    /// Obtém ou define o número do CPF do paciente.
    /// </summary>
    public string Cpf { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a data de nascimento do paciente.
    /// </summary>
    public DateTime DataNascimento { get; set; }

    /// <summary>
    /// Obtém ou define a lista de consultas associadas ao paciente.
    /// </summary>
    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    /// <summary>
    /// Obtém ou define a referência de navegação para o usuário associado ao paciente.
    /// </summary>
    public virtual Usuario? IdUsuarioNavigation { get; set; } = null!;
}
