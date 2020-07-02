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
    public class CategoriaHandler : INotificationHandler<CategoriaNotification>
    {
        private readonly ICategoriaCaching categoriaCaching;

        public CategoriaHandler(ICategoriaCaching categoriaCaching)
        {
            this.categoriaCaching = categoriaCaching;
        }

        public Task Handle(CategoriaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var categoriaDTO = new CategoriaDTO
                {
                    Id = notification.Categoria.Id,
                    Nome = notification.Categoria.Nome,
                    Descricao = notification.Categoria.Descricao
                };

                switch (notification.Action)
                {
                    case ActionNotification.Criar:
                        categoriaCaching.Add(categoriaDTO);
                        break;

                    case ActionNotification.Atualizar:
                        categoriaCaching.Update(categoriaDTO);
                        break;

                    case ActionNotification.Excluir:
                        categoriaCaching.Remove(categoriaDTO);
                        break;
                }
            });
        }
    }
}
