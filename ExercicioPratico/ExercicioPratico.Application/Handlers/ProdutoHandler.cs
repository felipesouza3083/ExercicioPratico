using AutoMapper;
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
        private readonly IMapper mapper;

        public ProdutoHandler(IProdutoCaching produtoCaching, IMapper mapper)
        {
            this.produtoCaching = produtoCaching;
            this.mapper = mapper;
        }

        public Task Handle(ProdutoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var produtoDTO = mapper.Map<ProdutoDTO>(notification.Produto);

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
