using BancoDados.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Exercicios.Mapping
{
    public class AvaliacaoMap: EntityTypeConfiguration<Avaliacao>
    {
        public AvaliacaoMap()
        {
            this.HasKey(t => t.Id);

            this.ToTable("Avaliacoes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            this.Property(t => t.ClassificacaoId).HasColumnName("ClassificacaoId");
            this.Property(t => t.TransportadoraId).HasColumnName("TransportadoraId");

        }
    }
}