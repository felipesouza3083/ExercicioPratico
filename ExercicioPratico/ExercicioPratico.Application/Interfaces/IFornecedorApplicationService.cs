using ExercicioPratico.Application.Commands.Fornecedores;
using ExercicioPratico.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioPratico.Application.Interfaces
{
    public interface IFornecedorApplicationService
    {
        Task Add(CreateFornecedorCommand command);
        Task Update(UpdateFornecedorCommand command);
        Task Delete(DeleteFornecedorCommand command);
        List<FornecedorDTO> GetAll();
        FornecedorDTO GetById(string id);
    }
}
