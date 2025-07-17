namespace BioGenom.DB.Repositories
{
    public interface IProductRepository
    {
        Task<bool> ExistsAsync(Guid productId);
    }
}
