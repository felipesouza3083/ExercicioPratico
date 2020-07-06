using ExercicioPratico.Application.Commands.Categorias;
using ExercicioPratico.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Interfaces
{
    public interface ICategoriaApplicationService
    {
        void Add(CreateCategoriaCommand command);
        void Update(UpdateCategoriaCommand command);
        void Remove(DeleteCategoriaCommand command);
        List<CategoriaDTO> GetAll();
        CategoriaDTO GetById(string id);
    }
}
