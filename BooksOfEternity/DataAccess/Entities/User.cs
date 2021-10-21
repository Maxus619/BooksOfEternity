using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace BooksOfEternity.DataAccess.Entities
{
    public partial class User
    {
        public User()
        {
            BookRecords = new HashSet<BookRecord>();
            Books = new HashSet<Book>();
            Likes = new HashSet<Like>();
            UsersInfos = new HashSet<UsersInfo>();
        }

        public long Id { get; set; }

        [JsonIgnore]
        public string Login { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }

        public virtual ICollection<BookRecord> BookRecords { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<UsersInfo> UsersInfos { get; set; }
    }
}
