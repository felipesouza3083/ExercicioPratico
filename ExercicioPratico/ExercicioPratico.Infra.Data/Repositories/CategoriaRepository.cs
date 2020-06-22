using ExercicioPratico.Domain.Interfaces.Repositories;
using ExercicioPratico.Domain.Models;
using ExercicioPratico.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Infra.Data.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(SqlContext context) : base(context) { }
    }
}
