using ExercicioPratico.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Notifications
{
    public class CategoriaNotification : INotification
    {
        public Categoria Categoria { get; set; }
        public ActionNotification Action { get; set; }
    }
}
