using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

/// <summary>
/// Classe que representa a entidade Comentario.
/// </summary>
public partial class Comentario
{
    /// <summary>
    /// Obtém ou define o identificador único do comentário.
    /// </summary>
    public Guid IdComentario { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Obtém ou define o identificador único da consulta associada ao comentário.
    /// </summary>
    public Guid IdConsulta { get; set; }

    /// <summary>
    /// Obtém ou define a descrição do comentário.
    /// </summary>
    public string Descricao { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a data de criação do comentário.
    /// </summary>
    public DateTime DataCriacao { get; set; }

    /// <summary>
    /// Obtém ou define um valor que indica se o comentário deve ser exibido.
    /// </summary>
    public bool Exibe { get; set; }

    /// <summary>
    /// Obtém ou define a navegação para a consulta associada ao comentário.
    /// </summary>
    public virtual Consulta? IdConsultaNavigation { get; set; } = null!;
}
