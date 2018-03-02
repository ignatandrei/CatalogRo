using System;
using System.Collections.Generic;

namespace CatalogDAL.Models
{
    public partial class Format
    {
        public Format()
        {
            Resursa = new HashSet<Resursa>();
        }

        public int Idformat { get; set; }
        public string Nume { get; set; }
        public string EnglishName { get; set; }

        public ICollection<Resursa> Resursa { get; set; }
    }
}
