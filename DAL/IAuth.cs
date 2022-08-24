using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL
{
    public interface IAuth
    {
        //TokenAccess Authenticate(string username, string password);

        Token Authenticate(string Email, string Password);
        bool IsAuthenticated(string token);
        bool IsAdminAuthenticated(string token);
        bool Logout(int id);
    }
}
