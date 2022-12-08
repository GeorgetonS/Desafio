using Desafio.Imap.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Imap.Api.Mapping;

public class CandidatoMap
{
    public class EnderecoMap : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.ToTable("candidato")
                .HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnType("VARCHAR").HasMaxLength(50);
            builder.Property(x => x.Idade);
            builder.Property(x => x.Telefone).HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.Cpf).HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(x => x.Email).HasColumnType("VARCHAR").HasMaxLength(50);
            builder.HasOne(x => x.Endereco).WithOne().HasForeignKey<Endereco>(x => x.CandidatoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
