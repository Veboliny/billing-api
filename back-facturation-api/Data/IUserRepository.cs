using back_facturation_api.Models;

namespace back_facturation_api.Data
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
    }
}
