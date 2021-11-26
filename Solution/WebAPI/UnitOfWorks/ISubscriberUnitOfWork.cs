using WebAPI.Repositories;

namespace WebAPI.UnitOfWorks
{
    public interface ISubscriberUnitOfWork
    {
        ISubscriberRepository subscriberRepo { get; }

        int SaveUoW();
    }
}