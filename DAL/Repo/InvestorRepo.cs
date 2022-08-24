using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repo
{
    public class InvestorRepo : IRepository<Investor, int>
    {
        private investrositeEntities db;
        public InvestorRepo(investrositeEntities db)
        {
            this.db = db;
        }
        public bool Add(Investor obj)
        {
            db.Investors.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public void Delete(Investor e)
        {
            var n = db.Investors.FirstOrDefault(en => en.Id == e.Id);
            db.Investors.Remove(n);
            db.SaveChanges();
        }

        public bool Edit(Investor e)
        {
            var n = db.Investors.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(n).CurrentValues.SetValues(e);
            db.SaveChanges();
            if (db.SaveChanges() != 0) return true;
            return false;
        }
        

        public Investor Get(int id)
        {
            return db.Investors.FirstOrDefault(x => x.Id == id);
        }

        public List<Investor> Get()
        {
            return db.Investors.ToList();
        }

        public List<Investor> Search(string Name)
        {
            //Token t = null;
            var searchchk = db.Investors.Where(x => x.Name.StartsWith(Name)).ToList();
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
