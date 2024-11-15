﻿using BooksReviewApp.Core.Domain.Interfaces;

namespace BooksReviewApp.Domain.Entities
{
    public class User : IModel
    {
        public Guid Id { get; set; }
        public Guid ApplicationUserId { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }

        // one-to-many relationship
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
