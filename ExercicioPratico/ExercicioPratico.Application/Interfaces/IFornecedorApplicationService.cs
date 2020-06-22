using ExercicioPratico.Application.Commands.Fornecedores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Interfaces
{
    public interface IFornecedorApplicationService : IDisposable
    {
        void Add(CreateFornecedorCommand command);
        void Update(UpdateFornecedorCommand command);
        void Delete(DeleteFornecedorCommand command);
    }
}
