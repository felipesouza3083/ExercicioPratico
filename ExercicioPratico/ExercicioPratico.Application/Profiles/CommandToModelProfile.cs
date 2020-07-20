using AutoMapper;
using ExercicioPratico.Application.Commands.Categorias;
using ExercicioPratico.Application.Commands.Fornecedores;
using ExercicioPratico.Application.Commands.Produtos;
using ExercicioPratico.Application.Commands.Usuarios;
using ExercicioPratico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Profiles
{
    public class CommandToModelProfile : Profile
    {
        public CommandToModelProfile()
        {
            #region Usuarios

            CreateMap<CreateUsuarioCommand, Usuario>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid())
                .AfterMap((src, dest) => dest.DataCriacao = DateTime.Now);

            #endregion

            #region Categorias

            CreateMap<CreateCategoriaCommand, Categoria>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid());

            CreateMap<UpdateCategoriaCommand, Categoria>()
                .AfterMap((src, dest) => dest.Id = Guid.Parse(src.Id));

            CreateMap<DeleteCategoriaCommand, Categoria>()
                .AfterMap((src, dest) => dest.Id = Guid.Parse(src.Id));

            #endregion

            #region Fornecedores

            CreateMap<CreateFornecedorCommand, Fornecedor>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid());

            CreateMap<UpdateFornecedorCommand, Fornecedor>()
                .AfterMap((src, dest) => dest.Id = Guid.Parse(src.Id));

            CreateMap<DeleteFornecedorCommand, Fornecedor>()
                .AfterMap((src, dest) => dest.Id = Guid.Parse(src.Id));

            #endregion

            #region Produtos

            CreateMap<CreateProdutoCommand, Produto>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid());

            CreateMap<UpdateProdutoCommand, Produto>()
                .AfterMap((src, dest) => dest.Id = Guid.Parse(src.Id));

            CreateMap<DeleteProdutoCommand, Produto>()
                .AfterMap((src, dest) => dest.Id = Guid.Parse(src.Id));

            #endregion
        }
    }
}
