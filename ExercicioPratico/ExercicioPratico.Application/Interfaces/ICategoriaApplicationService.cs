using ExercicioPratico.Application.Commands.Categorias;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Interfaces
{
    public interface ICategoriaApplicationService:IDisposable
    {
        void Add(CreateCategoriaCommand command);
        void Update(UpdateCategoriaCommand command);
        void Remove(DeleteCategoriaCommand command);
    }
}
