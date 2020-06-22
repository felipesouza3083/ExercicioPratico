using ExercicioPratico.Application.Interfaces;
using ExercicioPratico.Application.Services;
using ExercicioPratico.Domain.Interfaces.Repositories;
using ExercicioPratico.Domain.Interfaces.Services;
using ExercicioPratico.Domain.Services;
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

            #endregion

            #region Domain

            services.AddTransient<ICategoriaDomainService,
                CategoriaDomainService>();

            services.AddTransient<IFornecedorDomainService,
                FornecedorDomainService>();

            services.AddTransient<IProdutoDomainService,
                ProdutoDomainService>();

            #endregion

            #region Infra

            services.AddTransient<ICategoriaRepository,
                CategoriaRepository>();

            services.AddTransient<IFornecedorRepository,
                FornecedorRepository>();

            services.AddTransient<IProdutoRepository,
                ProdutoRepository>();

            services.AddTransient<IUnitOfWork,
                UnitOfWork>();

            #endregion
        }
    }
}
