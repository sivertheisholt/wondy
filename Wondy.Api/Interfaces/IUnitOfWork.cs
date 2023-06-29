namespace Wondy.Api.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Complete();
        bool HasChanged();
    }
}