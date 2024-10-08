﻿using BooksReviewApp.Core.Domain.Interfaces;

namespace BooksReviewApp.Domain.Entities
{
    public class Author : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }

        // one-to-many relationship
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
