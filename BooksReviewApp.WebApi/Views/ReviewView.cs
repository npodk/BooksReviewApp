﻿namespace BooksReviewApp.WebApi.Views
{
    public class ReviewView
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        public Guid BookId { get; set; }
        public string BookTitle { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
