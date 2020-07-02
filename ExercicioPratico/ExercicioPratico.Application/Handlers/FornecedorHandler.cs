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
    public class FornecedorHandler:INotificationHandler<FornecedorNotification>
    {
        private readonly IFornecedorCaching fornecedorCaching;

        public FornecedorHandler(IFornecedorCaching fornecedorCaching)
        {
            this.fornecedorCaching = fornecedorCaching;
        }

        public Task Handle(FornecedorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var fornecedorDTO = new FornecedorDTO
                {
                    Id = notification.Fornecedor.Id,
                    Nome = notification.Fornecedor.Nome,
                    Cnpj = notification.Fornecedor.Cnpj,
                    Email = notification.Fornecedor.Email,
                    RazaoSocial = notification.Fornecedor.RazaoSocial,
                    Telefone = notification.Fornecedor.Telefone
                };

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
