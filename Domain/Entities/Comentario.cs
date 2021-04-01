using Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Comentario : Entity
    {
        public string Texto { get; set; }

        public Guid IdPostagem { get; set; }
        [ForeignKey("IdPostagem")]
        public Postagem Postagem { get; set; }
    }
}
