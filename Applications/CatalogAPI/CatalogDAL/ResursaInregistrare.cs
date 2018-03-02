namespace CatalogDAL.Models
{
    public partial class ResursaInregistrare:ISerializeWithoutRelations
    {
        public void DestroyObjectsRelationship()
        {
            this.IdentuziastNavigation = null;
            this.ResursaValoare = null;
            this.Resursa = null;
        }
    }
}
