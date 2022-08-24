using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;
using System.Data.SqlClient;

namespace DAL.Repo
{
    public class EntrepreneurRepo : IRepository<Entrepreneur, int>
    {
        private investrositeEntities db;
        public EntrepreneurRepo(investrositeEntities db)
        {
            this.db = db;
        }
        public bool Add(Entrepreneur obj)
        {
            db.Entrepreneurs.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public void Delete(Entrepreneur e)
        {
            var n = db.Entrepreneurs.FirstOrDefault(en => en.Id == e.Id);
            db.Entrepreneurs.Remove(n);
            db.SaveChanges();
        }

        public bool Edit(Entrepreneur e)
        {
            var n = db.Entrepreneurs.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(n).CurrentValues.SetValues(e);
            db.SaveChanges();
            if (db.SaveChanges() != 0) return true;
            return false;
        }
        
        public Entrepreneur Get(int id)
        {
            return db.Entrepreneurs.FirstOrDefault(x => x.Id == id);
        }

        public List<Entrepreneur> Get()
        {
            return db.Entrepreneurs.ToList();
        }
        public bool Authenticate(string uname, string pass)
        {
            return true;
        }

        public List<Entrepreneur> Search(string Name)
        {
            //Token t = null;
            var searchchk = db.Entrepreneurs.Where(x => x.Name.StartsWith(Name)).ToList();
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
