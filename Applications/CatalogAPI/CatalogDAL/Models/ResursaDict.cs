using System;
using System.Collections.Generic;

namespace CatalogDAL.Models
{
    public partial class ResursaDict
    {
        public ResursaDict()
        {
            ResursaValoare = new HashSet<ResursaValoare>();
        }

        public long Id { get; set; }
        public string Nume { get; set; }
        public string Valoare { get; set; }
        public string TableValue { get; set; }

        public ICollection<ResursaValoare> ResursaValoare { get; set; }
    }
}
