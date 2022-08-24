using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;
using DAL.Repo;

namespace DAL
{
    public class DataAccessFactory
    {
        static investrositeEntities db = new investrositeEntities();
        public static IRepository<Entrepreneur, int> EntrepreneurDataAccess()
        {
            return new EntrepreneurRepo(db);
        }
        public static IRepository<Admin, int> AdminDataAccess()
        {
            return new AdminRepo(db);
        }

        public static IRepository<Manager, int> ManagerDataAccess()
        {
            return new ManagerRepo(db);
        }
        public static IRepository<Investor, int> InvestorDataAccess()
        {
            return new InvestorRepo(db);
        }

        public static IRepository<Report, int> ReportDataAccess()
        {
            return new ReportRepo(db);
        }

        public static IRepository<Payment, int> PaymentDataAccess()
        {
            return new PaymentRepo(db);
        }

        public static IAuth AuthDataAccess()
        {
            return new AuthRepo(db);
        }



    }
}
