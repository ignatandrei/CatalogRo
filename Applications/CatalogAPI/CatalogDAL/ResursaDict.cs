namespace CatalogDAL.Models
{
    public partial class ResursaDict : ISerializeWithoutRelations
    {
        public void DestroyObjectsRelationship()
            
        {
            this.ResursaValoare = null;            
        }
    }
}
