﻿using Application.Common.Responses;
using CrossCutting.Models;

namespace Application.Features.Books.Commands.Create;

public class CreateBookCommand : IRequest<ReturnMessage<BookWithPurchasePriceResponse>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string Edition { get; set; }
    public string Language { get; set; }
    public DateTime PublicationDate { get; set; }
    public Guid AuthorId { get; set; }
    public Guid PublisherId { get; set; }
    public Guid CategoryId { get; set; }
    public decimal? PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Height { get; set; }
    public decimal? Length { get; set; }
    public decimal? Width { get; set; }
    public int Isbn { get; set; }
    public int CurrentInventory { get; set; }
    public int? Pages { get; set; }
}