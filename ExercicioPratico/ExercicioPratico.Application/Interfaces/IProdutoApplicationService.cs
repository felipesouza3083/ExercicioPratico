using ExercicioPratico.Application.Commands.Produtos;
using ExercicioPratico.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Interfaces
{
    public interface IProdutoApplicationService
    {
        void Add(CreateProdutoCommand command);
        void Update(UpdateProdutoCommand command);
        void Remove(DeleteProdutoCommand command);
        List<ProdutoDTO> GetAll();
        ProdutoDTO GetById(string id);
    }
}
