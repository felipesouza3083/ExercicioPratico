using ExercicioPratico.Application.Commands.Categorias;
using ExercicioPratico.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioPratico.Application.Interfaces
{
    public interface ICategoriaApplicationService
    {
        Task Add(CreateCategoriaCommand command);
        Task Update(UpdateCategoriaCommand command);
        Task Remove(DeleteCategoriaCommand command);
        List<CategoriaDTO> GetAll();
        CategoriaDTO GetById(string id);
    }
}
