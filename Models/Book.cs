using System;
using BooksAndBooks.Models.Enums;

namespace BooksAndBooks.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author {get; set; }
        public DateTime PublishYear { get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; }
    }
}