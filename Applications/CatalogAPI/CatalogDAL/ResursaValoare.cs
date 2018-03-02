namespace CatalogDAL.Models
{
    public partial class ResursaValoare : ISerializeWithoutRelations
    {
        public void DestroyObjectsRelationship()
        {
            this.IdresursaDictNavigation = null;
            this.Unique = null;            
        }
    }
}
