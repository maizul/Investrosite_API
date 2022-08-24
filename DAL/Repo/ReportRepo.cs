using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repo
{
    public class ReportRepo : IRepository<Report, int>
    {
        private investrositeEntities db;

        public ReportRepo(investrositeEntities db)
        {
            this.db = db;
        }
        public bool Add(Report obj)
        {
            db.Reports.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public Report Get(int id)
        {
            return db.Reports.FirstOrDefault(x => x.Id == id);
        }

        public List<Report> Get()
        {
            return db.Reports.ToList();
        }

        public Admin Search(string Name)
        {
            throw new NotImplementedException();
        }

        void IRepository<Report, int>.Delete(Report e)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Report, int>.Edit(Report obj)
        {
            throw new NotImplementedException();
        }

        List<Report> IRepository<Report, int>.Search(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
