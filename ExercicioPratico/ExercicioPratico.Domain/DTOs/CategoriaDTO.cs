using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.DTOs
{
    public class CategoriaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
