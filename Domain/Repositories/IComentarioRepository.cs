using Domain.Entities;
using System;

namespace Domain.Repositories
{
    public interface IComentarioRepository
    {
        Comentario Buscar(Guid id);
    }
}
