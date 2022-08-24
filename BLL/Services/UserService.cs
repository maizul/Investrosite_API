using BLL.BusinessEntity;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static TokenModel Authenticate(string Email, string Password)
        {
            var data = DataAccessFactory.AuthDataAccess().Authenticate(Email, Password);
            if (data != null)
            {
                TokenModel tokenModel = new TokenModel()
                {
                    Id = data.Id,
                    UserId = data.UserId,
                    TokenC = data.TokenC,
                    CreatedAt = data.CreatedAt,
                    ExpiredAt = data.ExpiredAt
                };

                return tokenModel;
            }
            return null;
        }
        public static bool IsAuthenticated(string token)
        {
            var authCheck = DataAccessFactory.AuthDataAccess().IsAuthenticated(token);
            return authCheck;
        }

        public static bool AdminIsAuthenticated(string token)
        {
            var authCheck = DataAccessFactory.AuthDataAccess().IsAdminAuthenticated(token);
            return authCheck;
        }


        public static bool Logout(int uid)
        {
            var logout = DataAccessFactory.AuthDataAccess().Logout(uid);
            return logout;
        }
    }
}
