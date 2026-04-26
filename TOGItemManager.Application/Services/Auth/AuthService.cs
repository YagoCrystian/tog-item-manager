using TOGItemManager.Application.DTOs.Auth.Requests;
using TOGItemManager.Application.DTOs.Auth.Responses;
using TOGItemManager.Application.Seguranca;
using TOGItemManager.Application.Services.Auth.Interfaces;
using TOGItemManager.Domain.Entidades.Usuarios.Interfaces;

namespace TOGItemManager.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly JwtTokenServico jwtTokenServico;

        public AuthService(IUsuarioRepositorio usuarioRepositorio, JwtTokenServico jwtTokenServico)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.jwtTokenServico = jwtTokenServico;
        }

        public LoginResponse Login(LoginRequest request)
        {
            var usuario = usuarioRepositorio.ObterPorEmail(request.Email);

            if(usuario == null)
                throw new ArgumentException("Usuário ou senha inválidos.");

            bool senhaValidada = PasswordHasher.Verificar(
                request.Senha, 
                usuario.Senha
            );

            if(!senhaValidada)
                throw new ArgumentException("Usuário ou senha inválidos.");

            var token = jwtTokenServico.GerarToken(usuario);

            return new LoginResponse(token);

        }
    }
}