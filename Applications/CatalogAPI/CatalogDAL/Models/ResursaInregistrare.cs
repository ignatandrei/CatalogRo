using System;
using System.Collections.Generic;

namespace CatalogDAL.Models
{
    public partial class ResursaInregistrare
    {
        public ResursaInregistrare()
        {
            Resursa = new HashSet<Resursa>();
            ResursaValoare = new HashSet<ResursaValoare>();
        }

        public long Identuziast { get; set; }
        public Guid UniqueId { get; set; }
        public DateTime DataIntroducere { get; set; }

        public Entuziast IdentuziastNavigation { get; set; }
        public ICollection<Resursa> Resursa { get; set; }
        public ICollection<ResursaValoare> ResursaValoare { get; set; }
    }
}
