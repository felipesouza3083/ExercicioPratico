using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Commands.Categorias
{
    public class UpdateCategoriaCommand
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
