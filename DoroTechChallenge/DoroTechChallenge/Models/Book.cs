﻿namespace DoroTechChallenge.Models;

public class Book
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime PublishedAt { get; set; }
    public int AuthorId { get; set; }
    public int GenreId { get; set; }

    public virtual Author Author { get; set; }
    public virtual Genre Genre { get; set; }
    public virtual List<PublishingCompany> PublishingCompanies { get; set; }
}
