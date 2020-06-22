using ExercicioPratico.Application.Commands.Produtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Interfaces
{
    public interface IProdutoApplicationService : IDisposable
    {
        void Add(CreateProdutoCommand command);
        void Update(UpdateProdutoCommand command);
        void Remove(DeleteProdutoCommand command);
    }
}
