using ExercicioPratico.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Notifications
{
    public class FornecedorNotification : INotification
    {
        public Fornecedor Fornecedor { get; set; }
        public ActionNotification Action { get; set; }
    }
}
