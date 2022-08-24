using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Database;
using DAL;

namespace DAL.Repo
{
    public class AuthRepo : IAuth
    {
        investrositeEntities db;
        public AuthRepo(investrositeEntities db)
        {
            this.db = db;
        }
        public Token Authenticate(string Email, string Password)
        {
            Token t = null;
            var authcheck = db.Admins.FirstOrDefault(u => u.Email == Email && u.Password == Password);
            if (authcheck != null)
            {
                //var r = new Random();
                var g = Guid.NewGuid();
                var token = g.ToString();
                t = new Token()
                {
                    UserId = authcheck.Id,
                    TokenC = token,
                    CreatedAt = DateTime.Now,
                    ExpiredAt = DateTime.Now.AddMinutes(30)
                };
                db.Tokens.Add(t);
                db.SaveChanges();
                return t;
            }
            else
            {
                return null;
            }
        }

        public bool IsAuthenticated(string token)
        {
            var tokencheck = db.Tokens.FirstOrDefault(t => t.TokenC.Equals(token) && DateTime.Compare((DateTime)t.ExpiredAt, DateTime.Now) > 0);

            if (tokencheck != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsAdminAuthenticated(string token)
        {
            //DateTime.Compare(t1, t2);
            //Less than zero t1 is earlier than t2.
            //Zero t1 is the same as t2.
            //Greater than zero   t1 is later than t2.
            using (investrositeEntities db = new investrositeEntities())
            {
                var tokencheck = db.Tokens.FirstOrDefault(t => t.TokenC.Equals(token) && DateTime.Compare((DateTime)t.ExpiredAt, DateTime.Now) > 0);
                var userType = (from t in db.Tokens
                                join u in db.Admins on t.UserId equals u.Id
                                where t.TokenC.Equals(token) && u.Role.Equals("Admin")
                                select new
                                {
                                    u.Role
                                }).ToList();
                var utype = "";
                foreach (var item in userType)
                {
                    utype = item.Role.ToString();
                }
                if (tokencheck != null && utype.Equals("Admin"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        public bool Logout(int uid)
        {
            var data = db.Tokens.FirstOrDefault(t => t.UserId == uid && DateTime.Compare((DateTime)t.CreatedAt, DateTime.Now) < 0 && DateTime.Compare((DateTime)t.ExpiredAt, DateTime.Now) > 0);
            if (data != null)
            {
                data.ExpiredAt = DateTime.Now;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
