using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        public FacebookContext Context { get; private set; }

        public PostagemRepository(FacebookContext context)
        {
            Context = context;
        }

        public List<Postagem> Listar(string palavrasChave = null)
        {
            if (palavrasChave != null)
                return Context
                    .Postagens
                    .Include(p => p.Comentarios)
                    .AsNoTracking()
                    .Where(p => p.Texto.ToLower().Contains(palavrasChave))
                    .OrderBy(p => p.DataCriacao)
                    .ToList();
            else
                return Context
                    .Postagens
                    .Include(p => p.Comentarios)
                    .AsNoTracking()
                    .OrderBy(p => p.DataCriacao)
                    .ToList();
        }

        public Postagem Buscar(Guid id)
        {
            return Context
                .Postagens
                .Include(p => p.Comentarios)
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
