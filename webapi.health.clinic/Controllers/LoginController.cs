using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;
using webapi.health.clinic.ViewModels;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador responsável pela autenticação e geração de tokens de acesso.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Construtor padrão do LoginController.
        /// </summary>
        public LoginController() => _usuarioRepository = new UsuarioRepository();

        /// <summary>
        /// Rota responsável por autenticar um usuário e gerar um token de acesso.
        /// </summary>
        /// <param name="usuario">As credenciais de login do usuário.</param>
        /// <returns>Um token de acesso JWT em caso de sucesso, ou uma mensagem de erro em caso contrário.</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                // Tenta buscar o usuário por e-mail e senha.
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                    return StatusCode(401, "Email ou senha inválidos.");

                // Gera as reivindicações (claims) para o token.
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()!),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation!.TituloTipoUsuario!),
            };

                // Configura a chave e credenciais de assinatura.
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("health-clinic-webapi-authentication-key"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Cria o token JWT.
                var token = new JwtSecurityToken(
                    issuer: "webapi.health.clinic",
                    audience: "webapi.health.clinic",
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}