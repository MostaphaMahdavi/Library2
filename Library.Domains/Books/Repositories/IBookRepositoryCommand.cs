﻿using System.Threading.Tasks;
using Library.Domains.Books.Dtos;
using Library.Domains.Books.Entities;

namespace Library.Domains.Books.Repositories
{
    public interface IBookRepositoryCommand
    {
        Task AddBook(AddBookInfo book);
    }
}