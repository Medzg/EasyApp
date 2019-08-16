using EasyApp.Model;
using System.Threading.Tasks;

namespace EasyApp.DataService.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> CheckCredentials(string username,string password);
        Task<User> CheckByUsername(string username);
    }
}