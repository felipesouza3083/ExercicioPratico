using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExercicioPratico.Application.Commands.Produtos;
using ExercicioPratico.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioPratico.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplicationService produtoApplicationService;

        public ProdutoController(IProdutoApplicationService produtoApplicationService)
        {
            this.produtoApplicationService = produtoApplicationService;
        }

        [HttpPost]
        public IActionResult Post(CreateProdutoCommand command)
        {
            try
            {
                produtoApplicationService.Add(command);

                return Ok(new { Message = "Produto cadastrado com sucesso" });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(UpdateProdutoCommand command)
        {
            try
            {
                produtoApplicationService.Update(command);

                return Ok(new { Message = "Produto ataulizado com sucesso" });
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
                var command = new DeleteProdutoCommand { Id = id };

                produtoApplicationService.Remove(command);

                return Ok(new { Message = "Produto excluído com sucesso" });
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
                return Ok(produtoApplicationService.GetAll());
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
                return Ok(produtoApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}