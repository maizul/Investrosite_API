using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repo
{
    public class AdminRepo : IRepository <Admin, int>
    {
        private investrositeEntities db;
        public AdminRepo(investrositeEntities db)
        {
            this.db = db;
        }
        public bool Add(Admin obj)
        {
            db.Admins.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public void Delete(Admin e)
        {
            var n = db.Admins.FirstOrDefault(en => en.Id == e.Id);
            db.Admins.Remove(n);
            db.SaveChanges();
        }

        public bool Edit(Admin e)
        {
            var n = db.Admins.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(n).CurrentValues.SetValues(e);
            db.SaveChanges();
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public Admin Get(int id)
        {
            return db.Admins.FirstOrDefault(x => x.Id == id);

        }
       
        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }
        public bool Authenticate(string uname, string pass)
        {
            return true;
        }

        public List<Admin> Search(string Name)
        {
            
            var searchchk = db.Admins.Where(x => x.Name.StartsWith(Name)).ToList();
            if (searchchk != null)
            {
                return searchchk;
            }
            else
            {
                return null;
            }
        }
    }
}
