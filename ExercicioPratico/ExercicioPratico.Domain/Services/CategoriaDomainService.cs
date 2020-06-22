using ExercicioPratico.Domain.Interfaces.Repositories;
using ExercicioPratico.Domain.Interfaces.Services;
using ExercicioPratico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.Services
{
    public class CategoriaDomainService:BaseDomainService<Categoria>, ICategoriaDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoriaDomainService(IUnitOfWork unitOfWork)
            :base(unitOfWork.CategoriaRepository)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
