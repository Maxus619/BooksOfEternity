using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace BooksOfEternity.DataAccess.Entities
{
    public partial class BookRecord
    {
        public BookRecord()
        {
            Likes = new HashSet<Like>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public long BookId { get; set; }
        public string Text { get; set; }
        public string Sort { get; set; }

        [JsonIgnore]
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
