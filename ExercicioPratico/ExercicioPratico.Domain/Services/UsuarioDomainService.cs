using ExercicioPratico.Domain.Interfaces.Cryptography;
using ExercicioPratico.Domain.Interfaces.Repositories;
using ExercicioPratico.Domain.Interfaces.Services;
using ExercicioPratico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.Services
{
    public class UsuarioDomainService : BaseDomainService<Usuario>, IUsuarioDomainService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMD5service md5Service;

        public UsuarioDomainService(IUnitOfWork unitOfWork, IMD5service md5Service)
            : base(unitOfWork.UsuarioRepository)
        {
            this.unitOfWork = unitOfWork;
            this.md5Service = md5Service;
        }

        public override void Add(Usuario obj)
        {
            obj.Senha = md5Service.Encrypt(obj.Senha);
            base.Add(obj);
        }

        public override void Update(Usuario obj)
        {
            obj.Senha = md5Service.Encrypt(obj.Senha);
            base.Update(obj);
        }

        public Usuario Get(string email)
        {
            return unitOfWork.UsuarioRepository.Get(email);
        }

        public Usuario Get(string email, string senha)
        {
            return unitOfWork.UsuarioRepository.Get(email, md5Service.Encrypt(senha));
        }
    }
}
