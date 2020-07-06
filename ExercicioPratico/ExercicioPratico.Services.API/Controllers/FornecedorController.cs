using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ExercicioPratico.Application.Commands.Fornecedores;
using ExercicioPratico.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioPratico.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService fornecedorApplicationService;

        public FornecedorController(IFornecedorApplicationService fornecedorApplicationService)
        {
            this.fornecedorApplicationService = fornecedorApplicationService;
        }

        [HttpPost]
        public IActionResult Post(CreateFornecedorCommand command)
        {
            try
            {
                fornecedorApplicationService.Add(command);

                return Ok(new { Message = "Fornecedor cadastrado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(UpdateFornecedorCommand command)
        {
            try
            {
                fornecedorApplicationService.Update(command);

                return Ok(new { Message = "Fornecedor atualizado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var command = new DeleteFornecedorCommand { Id = id };

                fornecedorApplicationService.Delete(command);

                return Ok(new { Message = "Fornecedor excluído com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(fornecedorApplicationService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                return Ok(fornecedorApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}