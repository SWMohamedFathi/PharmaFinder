using PharmaFinder.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Service
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(decimal id);
        void CreateUser(User userData);
        void UpdateUser(User userData);
        void DeleteUser(decimal id);
    }
}
