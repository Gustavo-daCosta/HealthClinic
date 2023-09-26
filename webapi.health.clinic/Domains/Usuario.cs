using System;
using System.Collections.Generic;

namespace webapi.health.clinic.Domains;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public Guid IdTipoUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public virtual TipoDeUsuario IdTipoUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
