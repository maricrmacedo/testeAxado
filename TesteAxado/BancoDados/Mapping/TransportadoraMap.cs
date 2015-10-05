using BancoDados.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Exercicios.Mapping
{
    public class TransportadoraMap: EntityTypeConfiguration<Transportadora>
    {
        public TransportadoraMap()
        {
            this.HasKey(t => t.Id);

            this.ToTable("Transportadoras");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}