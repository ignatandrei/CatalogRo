namespace CatalogDAL.Models
{
    public partial class Entuziast : ISerializeWithoutRelations
    {
        public void DestroyObjectsRelationship()
        {
            this.ResursaInregistrare = null;
                        
        }
    }
}
