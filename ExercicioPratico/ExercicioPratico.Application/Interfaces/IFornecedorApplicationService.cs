using ExercicioPratico.Application.Commands.Fornecedores;
using ExercicioPratico.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Interfaces
{
    public interface IFornecedorApplicationService
    {
        void Add(CreateFornecedorCommand command);
        void Update(UpdateFornecedorCommand command);
        void Delete(DeleteFornecedorCommand command);
        List<FornecedorDTO> GetAll();
        FornecedorDTO GetById(string id);
    }
}
