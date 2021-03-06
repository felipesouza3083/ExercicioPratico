﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Commands.Produtos
{
    public class UpdateProdutoCommand : IRequest
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }
        public string CategoriaId { get; set; }
        public string FornecedorId { get; set; }
    }
}
