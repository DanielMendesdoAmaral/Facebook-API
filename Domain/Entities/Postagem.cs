using Shared.Entities;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Postagem : Entity
    {
        public string Texto { get; set; }

        public List<Comentario> Comentarios { get; set; }

        public Postagem()
        {
            Comentarios = new List<Comentario>();
        }
    }
}
