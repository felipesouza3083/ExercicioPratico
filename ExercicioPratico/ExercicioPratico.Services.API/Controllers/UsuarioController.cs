using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExercicioPratico.Application.Commands.Usuarios;
using ExercicioPratico.Application.Interfaces;
using ExercicioPratico.Services.API.Adapters;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace ExercicioPratico.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplicationService usuarioApplicationService;

        public UsuarioController(IUsuarioApplicationService usuarioApplicationService)
        {
            this.usuarioApplicationService = usuarioApplicationService;
        }

        [HttpPost]
        public IActionResult Post(CreateUsuarioCommand command)
        {
            try
            {
                usuarioApplicationService.Add(command);

                return Ok(new { Message = "Usuário criado com sucesso!" });
            }
            catch (ValidationException e) 
            { 
                return BadRequest(ValidationAdapter.Parse(e.Errors)); 
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate(AuthenticateUsuarioCommand command)
        {
            try
            {
                var token = usuarioApplicationService.Authenticate(command);

                if (token != null)
                    return Ok(new
                    {
                        Message = "Usuário autenticado com sucesso!",
                        AccessToken = token
                    });

                return BadRequest(new { Message = "Usuário não encontrado." });
            }
            catch (ValidationException e)
            {
                return BadRequest(ValidationAdapter.Parse(e.Errors));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
