using PRY20220115.Models;

namespace PRY20220115.Repository
{
    public interface IUserRepository
    {
        Task<int> Register(User user, string password);
        Task<string> Login(string userName, string password);
        Task<bool> ExistUser(string userName);
    }
}
