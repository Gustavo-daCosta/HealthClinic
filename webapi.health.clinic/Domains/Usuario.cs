using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

/// <summary>
/// Classe que representa a entidade Usuario.
/// </summary>
public partial class Usuario
{
    /// <summary>
    /// Obtém ou define o identificador único do usuário.
    /// </summary>
    public Guid IdUsuario { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Obtém ou define o identificador do tipo de usuário.
    /// </summary>
    public Guid IdTipoUsuario { get; set; }

    /// <summary>
    /// Obtém ou define o nome do usuário.
    /// </summary>
    public string Nome { get; set; } = null!;

    /// <summary>
    /// Obtém ou define o endereço de e-mail do usuário.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a senha do usuário.
    /// </summary>
    public string Senha { get; set; } = null!;

    /// <summary>
    /// Obtém ou define o número de telefone do usuário.
    /// </summary>
    public string Telefone { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a navegação para o tipo de usuário associado a este usuário.
    /// </summary>
    public virtual TipoDeUsuario? IdTipoUsuarioNavigation { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a lista de médicos associados a este usuário.
    /// </summary>
    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();

    /// <summary>
    /// Obtém ou define a lista de pacientes associados a este usuário.
    /// </summary>
    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
