namespace CatalogDAL.Models
{
    public interface ISerializeWithoutRelations
    {
        void DestroyObjectsRelationship();
    }
}
