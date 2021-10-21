using System;
using System.Collections.Generic;

#nullable disable

namespace BooksOfEternity.DataAccess.Entities
{
    public partial class Like
    {
        public long Id { get; set; }
        public long BookRecordId { get; set; }
        public long UserId { get; set; }

        public virtual BookRecord BookRecord { get; set; }
        public virtual User User { get; set; }
    }
}
