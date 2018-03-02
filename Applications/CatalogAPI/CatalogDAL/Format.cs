namespace CatalogDAL.Models
{
    public partial class Format : ISerializeWithoutRelations
    {
        public void DestroyObjectsRelationship()
        {                        
            this.Resursa = null;
        }
    }
}
