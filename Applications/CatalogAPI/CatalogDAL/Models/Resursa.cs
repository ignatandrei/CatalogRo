using System;
using System.Collections.Generic;

namespace CatalogDAL.Models
{
    public partial class Resursa
    {
        public Guid Id { get; set; }
        public Guid? UniqueId { get; set; }
        public string Titlu { get; set; }
        public string Autor { get; set; }
        public int Categorie { get; set; }
        public string Descriere { get; set; }
        public string Subiect { get; set; }
        public int Format { get; set; }
        public string UrlResursa { get; set; }
        public string Url2Resursa { get; set; }
        public string Note { get; set; }

        public Categorie CategorieNavigation { get; set; }
        public Format FormatNavigation { get; set; }
        public ResursaInregistrare Unique { get; set; }
    }
}
