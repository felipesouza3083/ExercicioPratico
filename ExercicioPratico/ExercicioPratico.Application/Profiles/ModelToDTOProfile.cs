using AutoMapper;
using ExercicioPratico.Domain.DTOs;
using ExercicioPratico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Profiles
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            #region Categorias

            CreateMap<Categoria, CategoriaDTO>();

            #endregion

            #region Fornecedores

            CreateMap<Fornecedor, FornecedorDTO>();

            #endregion

            #region Produtos

            CreateMap<Produto, ProdutoDTO>();

            #endregion

        }
    }
}
