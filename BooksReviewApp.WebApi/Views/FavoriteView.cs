﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReviewApp.WebApi.Views
{
    public class FavoriteView
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public Guid BookId { get; set; }
        public string BookTitle { get; set; }
    }
}
