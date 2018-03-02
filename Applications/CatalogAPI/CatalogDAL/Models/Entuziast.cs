using System;
using System.Collections.Generic;

namespace CatalogDAL.Models
{
    public partial class Entuziast
    {
        public Entuziast()
        {
            ResursaInregistrare = new HashSet<ResursaInregistrare>();
        }

        public long Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Note { get; set; }
        public bool Validat { get; set; }
        public string Parola { get; set; }

        public ICollection<ResursaInregistrare> ResursaInregistrare { get; set; }
    }
}
