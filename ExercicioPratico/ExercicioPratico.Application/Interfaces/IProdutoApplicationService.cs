using ExercicioPratico.Application.Commands.Produtos;
using ExercicioPratico.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioPratico.Application.Interfaces
{
    public interface IProdutoApplicationService
    {
        Task Add(CreateProdutoCommand command);
        Task Update(UpdateProdutoCommand command);
        Task Remove(DeleteProdutoCommand command);
        List<ProdutoDTO> GetAll();
        ProdutoDTO GetById(string id);
    }
}
