namespace CatalogDAL.Models
{
    public partial class Resursa:ISerializeWithoutRelations
    {
        public void DestroyObjectsRelationship()
        {
            this.CategorieNavigation = null;
            
            this.FormatNavigation = null;
            this.Unique = null;
        }
    }
}
