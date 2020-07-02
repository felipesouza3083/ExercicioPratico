using ExercicioPratico.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Notifications
{
    public class ProdutoNotification : INotification
    {
        public Produto Produto { get; set; }
        public ActionNotification Action { get; set; }
    }
}
