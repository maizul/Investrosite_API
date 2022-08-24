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
    public class ManagerService
    {
        public static ManagerModel Get(int id)
        {
            var req = DataAccessFactory.ManagerDataAccess().Get(id);
            var s = new ManagerModel()
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
        public static List<ManagerModel> Get()
        {
            var reqs = DataAccessFactory.ManagerDataAccess().Get();
            List<ManagerModel> data = new List<ManagerModel>();
            foreach (var r in reqs)
            {
                data.Add(new ManagerModel() { Id = r.Id, Name = r.Name, Email= r.Email, Password= r.Password, Phone= r.Phone, Role= r.Role});

            }
            return data;

        }
        public static void Add(ManagerModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ManagerModel, Manager>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Manager>(p);
            DataAccessFactory.ManagerDataAccess().Add(data);
        }

      
        public static void Edit(ManagerModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ManagerModel, Manager>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Manager>(p);
            DataAccessFactory.ManagerDataAccess().Edit(data);
        }

        public static void Delete(ManagerModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ManagerModel, Manager>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Manager>(p);
            DataAccessFactory.ManagerDataAccess().Delete(data);
        }

        public static List<ManagerModel> Search(string p)
        {
            var data = DataAccessFactory.ManagerDataAccess().Search(p);
            if (data != null)
            {
                List<ManagerModel> searchchk = new List<ManagerModel>();
                foreach (var r in data)
                {
                    searchchk.Add(new ManagerModel()
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
