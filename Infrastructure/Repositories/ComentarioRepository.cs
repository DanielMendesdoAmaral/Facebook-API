using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using System;

namespace Infrastructure.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        public FacebookContext Context { get; private set; }

        public ComentarioRepository(FacebookContext context)
        {
            Context = context;
        }

        public Comentario Buscar(Guid id)
        {
            return Context
                .Comentarios
                .Find(id);
        }
    }
}
