﻿using ExercicioPratico.Domain.Interfaces.Repositories;
using ExercicioPratico.Domain.Models;
using ExercicioPratico.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercicioPratico.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SqlContext context)
            : base(context)
        {

        }

        public Usuario Get(string email)
        {
            return context.Usuarios.FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario Get(string email, string senha)
        {
            return context.Usuarios.FirstOrDefault(u => u.Email.Equals(email)
                                                     && u.Senha.Equals(senha));
        }
    }
}
