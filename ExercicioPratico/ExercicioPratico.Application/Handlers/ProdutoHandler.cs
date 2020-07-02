using ExercicioPratico.Application.Notifications;
using ExercicioPratico.Domain.DTOs;
using ExercicioPratico.Domain.Interfaces.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExercicioPratico.Application.Handlers
{
    public class ProdutoHandler : INotificationHandler<ProdutoNotification>
    {
        private readonly IProdutoCaching produtoCaching;

        public ProdutoHandler(IProdutoCaching produtoCaching)
        {
            this.produtoCaching = produtoCaching;
        }

        public Task Handle(ProdutoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var produtoDTO = new ProdutoDTO
                {
                    Id = notification.Produto.Id,
                    Nome = notification.Produto.Nome,
                    Preco = notification.Produto.Preco,
                    Quantidade = notification.Produto.Quantidade,
                    DataCompra = notification.Produto.DataCompra,
                    Categoria = new CategoriaDTO { Id = notification.Produto.Categoria.Id },
                    Fornecedor = new FornecedorDTO { Id = notification.Produto.Fornecedor.Id },
                };

                switch (notification.Action)
                {
                    case ActionNotification.Criar:
                        produtoCaching.Add(produtoDTO);
                        break;

                    case ActionNotification.Atualizar:
                        produtoCaching.Update(produtoDTO);
                        break;

                    case ActionNotification.Excluir:
                        produtoCaching.Remove(produtoDTO);
                        break;
                }
            });
        }
    }
}
