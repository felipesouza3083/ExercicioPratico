using ExercicioPratico.Domain.Interfaces.Repositories;
using ExercicioPratico.Domain.Interfaces.Services;
using ExercicioPratico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.Services
{
    public class FornecedorDomainService : BaseDomainService<Fornecedor>, IFornecedorDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public FornecedorDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.FornecedorRepository)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
