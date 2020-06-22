using ExercicioPratico.Domain.Interfaces.Repositories;
using ExercicioPratico.Domain.Interfaces.Services;
using ExercicioPratico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.Services
{
    public class ProdutoDomainService : BaseDomainService<Produto>, IProdutoDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProdutoDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.ProdutoRepository)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
