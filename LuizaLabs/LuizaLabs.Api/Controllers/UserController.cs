using LuizaLabs.Service.User;
using LuizaLabs.Service.User.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaLabs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Cadastra um usuário novo
        /// </summary>
        /// <response code="201">Usuário cadastrado com sucesso</response>
        /// <response code="400">Dados do usuário inválidos</response>
        /// <response code="409">Já existe um usuário com esse email</response>
        /// <response code="500">Erro interno da aplicação</response>
        /// <param name="usuarioPost">Dados do usuário para cadastrar</param>
        /// <returns><see cref="UsuarioGetDto"/>Dados do usuário cadastrado</returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserRegisterResponseDto>> PostRegister([FromBody] UserRegisterRequestDto userRegister)
        {
            if (userRegister.Password != userRegister.PasswordConfirmation)
                return BadRequest(new { message = "Confirmação da senha é diferente da senha" });

            var novoUsuario = await _userService.Add(userRegister);
            return Created("", novoUsuario);
        }

        /// <summary>
        /// Faz o login do usuario
        /// </summary>
        /// <response code="200">Usuário logado com sucesso</response>
        /// <response code="400">Credenciais inválidas</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">Erro interno da aplicação</response>
        /// <param name="usuarioLogin"><see cref="UsuarioLoginDto"/>Dados de login</param>
        /// <returns><see cref="TokenUsuarioDto"/>Token de autenticação</returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserTokenResponseDto>> PostAuthenticate([FromBody] UserLoginRequestDto userLogin)
        {
            var token = await _userService.Login(userLogin);
            if (token == null)
                return BadRequest(new { message = "Credenciais inválidas" });

            return Ok(token);
        }

        /// <summary>
        /// Recupera senha do usuário
        /// </summary>
        /// <response code="200">E-mail enviado com sucesso para usuário</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">Erro interno da aplicação</response>
        /// <param name="email">Email do usuário para recuperação</param>
        [AllowAnonymous]
        [Route("password/reset")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> GetRecuperacaoSenha([FromQuery] string email)
        {
            await _userService.ResetPassword(email);
            return Ok();
        }

        /// <summary>
        /// Altera a senha de um usuário
        /// </summary>
        /// <response code="200">Senha alterada com sucesso</response>
        /// <response code="400">Dados do usuário inválidos</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">Erro interno da aplicação</response>
        /// <param name="usuarioPut">Dados do usuário para alterar a senha</param>
        [AllowAnonymous]
        [Route("password")]
        [HttpPut]
        [ProducesResponseType(20)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> PutSenha([FromBody] UserPutRequestDto usuarioPut)
        {
            if (usuarioPut.Password != usuarioPut.PasswordConfirmation)
                return BadRequest(new { message = "Confirmação da senha é diferente da senha" });

            await _userService.Update(usuarioPut);
            return Ok();
        }
    }
}
