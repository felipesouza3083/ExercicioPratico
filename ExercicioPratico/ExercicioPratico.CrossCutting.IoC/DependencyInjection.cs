using ExercicioPratico.Application.Interfaces;
using ExercicioPratico.Application.Services;
using ExercicioPratico.Domain.Interfaces.Cryptography;
using ExercicioPratico.Domain.Interfaces.Repositories;
using ExercicioPratico.Domain.Interfaces.Services;
using ExercicioPratico.Domain.Services;
using ExercicioPratico.Infra.Criptography;
using ExercicioPratico.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ExercicioPratico.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            #region Application

            services.AddTransient<ICategoriaApplicationService, 
                CategoriaApplicationService>();

            services.AddTransient<IFornecedorApplicationService,
                FornecedorApplicationService>();

            services.AddTransient<IProdutoApplicationService,
                ProdutoApplicationService>();

            services.AddTransient<IUsuarioApplicationService,
                UsuarioApplicationService>();

            #endregion

            #region Domain

            services.AddTransient<ICategoriaDomainService,
                CategoriaDomainService>();

            services.AddTransient<IFornecedorDomainService,
                FornecedorDomainService>();

            services.AddTransient<IProdutoDomainService,
                ProdutoDomainService>();

            services.AddTransient<IUsuarioDomainService,
                UsuarioDomainService>();

            #endregion

            #region Infra

            services.AddTransient<ICategoriaRepository,
                CategoriaRepository>();

            services.AddTransient<IFornecedorRepository,
                FornecedorRepository>();

            services.AddTransient<IProdutoRepository,
                ProdutoRepository>();

            services.AddTransient<IUsuarioRepository,
                UsuarioRepository>();

            services.AddTransient<IUnitOfWork,
                UnitOfWork>();

            services.AddTransient<IMD5service,
                MD5Service>();

            #endregion
        }
    }
}
