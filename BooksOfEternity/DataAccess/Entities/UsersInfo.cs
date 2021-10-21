using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace BooksOfEternity.DataAccess.Entities
{
    public partial class UsersInfo
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
