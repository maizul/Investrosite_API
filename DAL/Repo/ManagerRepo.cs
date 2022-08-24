using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repo
{
    public class ManagerRepo : IRepository<Manager, int>
    {
        private investrositeEntities db;
        public ManagerRepo(investrositeEntities db)
        {
            this.db = db;
        }
        public bool Add(Manager obj)
        {
            db.Managers.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public void Delete(Manager e)
        {
            var n = db.Managers.FirstOrDefault(en => en.Id == e.Id);
            db.Managers.Remove(n);
            db.SaveChanges();
        }

        public bool Edit(Manager e)
        {
            var n = db.Managers.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(n).CurrentValues.SetValues(e);
            db.SaveChanges();
            if (db.SaveChanges() != 0) return true;
            return false;
        }
        

        public Manager Get(int id)
        {
            return db.Managers.FirstOrDefault(x => x.Id == id);
        }

        public List<Manager> Get()
        {
            return db.Managers.ToList();
        }
        public bool Authenticate(string uname, string pass)
        {
            return true;
        }

        public List<Manager> Search(string Name)
        {
            //Token t = null;
            var searchchk = db.Managers.Where(x => x.Name.StartsWith(Name)).ToList();
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
