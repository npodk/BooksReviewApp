﻿namespace BooksReviewApp.WebApi.Dtos.User
{
    public class UpdateUserDto : CreateUserDto
    {
        public Guid Id { get; set; }
    }
}
