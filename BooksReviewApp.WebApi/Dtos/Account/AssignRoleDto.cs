﻿namespace BooksReviewApp.WebApi.Dtos.Account
{
    public class AssignRoleDto
    {
        public Guid UserId { get; set; }
        public string RoleName { get; set; }
    }
}
