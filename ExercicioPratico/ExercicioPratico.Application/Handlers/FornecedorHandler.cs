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
    public class FornecedorHandler : INotificationHandler<FornecedorNotification>
    {
        private readonly IFornecedorCaching fornecedorCaching;
        private readonly IMapper mapper;

        public FornecedorHandler(IFornecedorCaching fornecedorCaching, IMapper mapper)
        {
            this.fornecedorCaching = fornecedorCaching;
            this.mapper = mapper;
        }

        public Task Handle(FornecedorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var fornecedorDTO = mapper.Map<FornecedorDTO>(notification.Fornecedor);

                switch (notification.Action)
                {
                    case ActionNotification.Criar:
                        fornecedorCaching.Add(fornecedorDTO);
                        break;

                    case ActionNotification.Atualizar:
                        fornecedorCaching.Update(fornecedorDTO);
                        break;

                    case ActionNotification.Excluir:
                        fornecedorCaching.Remove(fornecedorDTO);
                        break;
                }
            });
        }
    }
}
