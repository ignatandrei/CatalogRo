﻿using System;
using System.Collections.Generic;

namespace CatalogDAL.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            InverseParentNavigation = new HashSet<Categorie>();
            Resursa = new HashSet<Resursa>();
        }

        public int Idcategorie { get; set; }
        public string Nume { get; set; }
        public int? Parent { get; set; }
        public string EnglishName { get; set; }

        public Categorie ParentNavigation { get; set; }
        public ICollection<Categorie> InverseParentNavigation { get; set; }
        public ICollection<Resursa> Resursa { get; set; }
    }
}
