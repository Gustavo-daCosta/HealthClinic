using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

/// <summary>
/// Classe que representa a entidade Prontuario.
/// </summary>
public partial class Prontuario
{
    /// <summary>
    /// Obtém ou define o identificador único do prontuário.
    /// </summary>
    public Guid IdProntuario { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Obtém ou define o identificador único da consulta associada a este prontuário.
    /// </summary>
    public Guid IdConsulta { get; set; }

    /// <summary>
    /// Obtém ou define a descrição do prontuário.
    /// </summary>
    public string Descricao { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a data de criação do prontuário.
    /// </summary>
    public DateTime DataCriacao { get; set; }

    /// <summary>
    /// Obtém ou define a navegação para a consulta associada a este prontuário.
    /// Pode ser nulo se a consulta não estiver definida.
    /// </summary>
    public virtual Consulta? IdConsultaNavigation { get; set; } = null!;
}
