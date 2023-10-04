using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

/// <summary>
/// Classe que representa a entidade TipoDeUsuario.
/// </summary>
public partial class TipoDeUsuario
{
    /// <summary>
    /// Obtém ou define o identificador único do tipo de usuário.
    /// </summary>
    public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Obtém ou define o título do tipo de usuário.
    /// </summary>
    public string? TituloTipoUsuario { get; set; }

    /// <summary>
    /// Obtém ou define a lista de usuários associados a este tipo de usuário.
    /// </summary>
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
