using System;
using System.Collections.Generic;

#nullable disable

namespace BooksOfEternity.DataAccess.Entities
{
    public partial class Book
    {
        public Book()
        {
            BookRecords = new HashSet<BookRecord>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short? Rating { get; set; }
        public int? Pages { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<BookRecord> BookRecords { get; set; }
    }
}
