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
    public class InvestorService
    {
        public static InvestorModel Get(int id)
        {
            var req = DataAccessFactory.InvestorDataAccess().Get(id);
            var s = new InvestorModel()
            {
                Id = req.Id,
                Name = req.Name,
                Email = req.Email,
                Phone = req.Phone,
                Password = req.Password,
                Role = req.Role
            };
            return s;

        }
        public static List<InvestorModel> Get()
        {
            var reqs = DataAccessFactory.InvestorDataAccess().Get();
            List<InvestorModel> data = new List<InvestorModel>();
            foreach (var r in reqs)
            {
                data.Add(new InvestorModel() { Id = r.Id, Name = r.Name, Email = r.Email, Password = r.Password, Phone = r.Phone, Role = r.Role });

            }
            return data;

        }

        public static void Delete(InvestorModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<InvestorModel, Investor>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Investor>(p);
            DataAccessFactory.InvestorDataAccess().Delete(data);
        }

        public static void Add(InvestorModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<InvestorModel, Investor>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Investor>(p);
            DataAccessFactory.InvestorDataAccess().Add(data);
        }


        public static void Edit(InvestorModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<InvestorModel, Investor>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Investor>(p);
            DataAccessFactory.InvestorDataAccess().Edit(data);
        }

        public static List<InvestorModel> Search(string p)
        {
            var data = DataAccessFactory.InvestorDataAccess().Search(p);
            if (data != null)
            {
                List<InvestorModel> searchchk = new List<InvestorModel>();
                foreach (var r in data)
                {
                    searchchk.Add(new InvestorModel()
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Email = r.Email,
                        Password = r.Password,
                        Phone = r.Phone,
                        Role = r.Role
                    });

                }
                return searchchk;
            }
            return null;
        }


    }
}
