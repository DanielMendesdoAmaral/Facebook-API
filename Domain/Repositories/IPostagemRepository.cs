using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IPostagemRepository
    {
        List<Postagem> Listar(string palavrasChave = null);
        Postagem Buscar(Guid id);
    }
}
