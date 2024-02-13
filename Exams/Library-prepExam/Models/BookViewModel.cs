﻿using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookViewModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength =10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50,MinimumLength =5)]
        public string Author { get; set; } = null!;

        [Required(AllowEmptyStrings =false)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        [StringLength(5000,MinimumLength =5)]
        public string Description { get; set; } = null!;

        [Range(1,int.MaxValue)]
        public int CategoryId { get; set; } 
    }
}
//Book
//• Has Id – a unique integer, Primary Key
//• Has Title – a string with min length 10 and max length 50 (required)
//• Has Author – a string with min length 5 and max length 50 (required)
//• Has Description – a string with min length 5 and max length 5000 (required)
//• Has ImageUrl – a string (required)
//• Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
//• Has CategoryId – an integer, foreign key (required)
//• Has Category – a Category (required)
//• Has UsersBooks – a collection of type IdentityUserBook