using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;
using DAL.Repo;
using DAL;
using BLL.BusinessEntity;
using AutoMapper;

namespace BLL.Services
{
    public class PaymentService
    {
        public static PaymentModel Get(int id)
        {
            var en = DataAccessFactory.PaymentDataAccess().Get(id);
            var s = new PaymentModel()
            {
                Id = en.Id,
                Amount = en.Amount,
                Eid = en.Eid,
                Iid = en.Iid
            };
            return s;

        }
        public static List<PaymentModel> Get()
        {
            var ens = DataAccessFactory.PaymentDataAccess().Get();
            List<PaymentModel> data = new List<PaymentModel>();
            foreach (var s in ens)
            {
                data.Add(new PaymentModel() { Id = s.Id, Amount = s.Amount, Eid = s.Eid, Iid =s.Iid  });

            }
            return data;

        }
    }
}
