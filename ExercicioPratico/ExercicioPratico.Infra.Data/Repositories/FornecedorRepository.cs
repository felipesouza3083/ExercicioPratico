using ExercicioPratico.Domain.Interfaces.Repositories;
using ExercicioPratico.Domain.Models;
using ExercicioPratico.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Infra.Data.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(SqlContext context) : base(context) { }
    }
}
