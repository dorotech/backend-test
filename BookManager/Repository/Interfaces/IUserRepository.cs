using BookManager.Model;

namespace BookManager.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository
    {
        public Task<User> login(Credential credential);
        public Task<bool> checkUserExists(User user);
    }
}