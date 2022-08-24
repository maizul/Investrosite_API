using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repo
{
    public  class PaymentRepo : IRepository<Payment, int>
    {
        private investrositeEntities db;
        public PaymentRepo(investrositeEntities db)
        {
            this.db = db;
        }
        public Payment Get(int id)
        {
            return db.Payments.FirstOrDefault(x => x.Id == id);
        }

        public List<Payment> Get()
        {
            return db.Payments.ToList();
        }

        public Admin Search(string Name)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Payment, int>.Add(Payment obj)
        {
            throw new NotImplementedException();
        }

        void IRepository<Payment, int>.Delete(Payment e)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Payment, int>.Edit(Payment obj)
        {
            throw new NotImplementedException();
        }

        List<Payment> IRepository<Payment, int>.Search(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
