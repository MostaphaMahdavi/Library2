using Library.Domains.Books.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccessCommands.Books.Configs
{
    public class BookConfig:IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);
            builder.Property(b => b.BookName).IsRequired(true).HasMaxLength(250);
            builder.Property(b => b.ImageName).IsRequired(true);
            builder.Property(b => b.ShabekNo).IsRequired(true).HasMaxLength(100);
            builder.Property(b => b.Subject).IsRequired(true).HasMaxLength(250);
            builder.Property(b => b.Content).IsRequired(true);
        }
    }
}