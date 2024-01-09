﻿using DoroTech.BookStore.Domain.Entities;

namespace DoroTech.BookStore.Infrastructure.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(book => book.Id);
        builder
            .Property(book => book.Title);
        builder
            .Property(book => book.Author);
        builder.Property(book => book.Description)
            .HasColumnType("nvarchar(max)")
            .IsRequired(false);
        builder.Property(book => book.Edition);
        builder.Property(book => book.Pages)
            .IsRequired(false);
        builder.Property(book => book.Language);
        builder.Property(book => book.PublicationDate);
        builder.Property(book => book.Cust)
           .HasPrecision(18, 2)
           .IsRequired(false);

        builder.Property(book => book.Price)
            .HasPrecision(18, 2);
        builder.Property(book => book.Isbn);
    }
}
