using Desafio.Imap.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Imap.Infra.Mapping;

public class EnderecoMap : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("endereco")
            .HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Rua).HasColumnType("VARCHAR").HasMaxLength(50);
        builder.Property(x => x.Complemento).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired(false);
        builder.Property(x => x.Numero);
        builder.Property(x => x.Cep).HasColumnType("VARCHAR").HasMaxLength(15);
        builder.Property(x => x.Cidade).HasColumnType("VARCHAR").HasMaxLength(50);
        builder.Property(x => x.Estado).HasColumnType("VARCHAR").HasMaxLength(50);
        builder.Property(x => x.CandidatoId);
    }
}
