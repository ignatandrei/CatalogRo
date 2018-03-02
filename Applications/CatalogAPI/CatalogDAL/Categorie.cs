using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogDAL.Models
{
    partial class Categorie : ISerializeWithoutRelations
    {
        public void DestroyObjectsRelationship()
        {
            this.InverseParentNavigation = null;
            this.ParentNavigation = null;
            this.Resursa = null;
        }
    }
}
