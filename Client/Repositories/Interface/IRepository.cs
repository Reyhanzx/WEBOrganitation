using Client.ViewModels;

namespace Client.Repositories.Interface
{
    public interface IRepository<Key, Entity> where Entity : class
    {
        Task<ListVM<Entity>> Get();
        Task<RespondVM<Entity?>> Get(Key id);
        Task<RespondStatusVM> Post(Entity entity);
        Task<RespondStatusVM> Put(Entity entity, Key id);
        Task<RespondStatusVM> Delete(Key key);
    }
}
