using System;
using System.Collections.Generic;

namespace CatalogDAL.Models
{
    public partial class ResursaValoare
    {
        public string Valoare { get; set; }
        public long IdresursaDict { get; set; }
        public Guid UniqueId { get; set; }

        public ResursaDict IdresursaDictNavigation { get; set; }
        public ResursaInregistrare Unique { get; set; }
    }
}
