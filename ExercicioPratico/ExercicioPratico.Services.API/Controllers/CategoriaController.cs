using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExercicioPratico.Application.Commands.Categorias;
using ExercicioPratico.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioPratico.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaApplicationService categoriaApplicationService;

        public CategoriaController(ICategoriaApplicationService categoriaApplicationService)
        {
            this.categoriaApplicationService = categoriaApplicationService;
        }

        [HttpPost]
        public IActionResult Post(CreateCategoriaCommand command)
        {
            try
            {
                categoriaApplicationService.Add(command);

                return Ok(new { Message = "Categoria cadastrada com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(UpdateCategoriaCommand command)
        {
            try
            {
                categoriaApplicationService.Update(command);

                return Ok(new { Message = "Categoria Atualizada com sucesso." });
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
                var command = new DeleteCategoriaCommand { Id = id };

                categoriaApplicationService.Remove(command);

                return Ok(new { Message = "Categoria excluída com sucesso." });
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
                return Ok(categoriaApplicationService.GetAll());
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
                return Ok(categoriaApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}