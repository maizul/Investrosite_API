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
    public class AdminService
    {
        public static AdminModel Get(int id)
        {
            var req = DataAccessFactory.AdminDataAccess().Get(id);
            var s = new AdminModel()
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
        public static List<AdminModel> Get()
        {
            var reqs = DataAccessFactory.AdminDataAccess().Get();
            List<AdminModel> data = new List<AdminModel>();
            foreach (var r in reqs)
            {
                data.Add(new AdminModel() { Id = r.Id, Name = r.Name, Email= r.Email, Password= r.Password, Phone= r.Phone, Role= r.Role});

            }
            return data;

        }
        public static void Add(AdminModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminModel, Admin>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Admin>(p);
            DataAccessFactory.AdminDataAccess().Add(data);
        }

      
        public static void Edit(AdminModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminModel, Admin>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Admin>(p);
            DataAccessFactory.AdminDataAccess().Edit(data);
        }

        public static void Delete(AdminModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminModel, Admin>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Admin>(p);
            DataAccessFactory.AdminDataAccess().Delete(data);
        }

        public static List<AdminModel> Search(string p)
        {
            var data = DataAccessFactory.AdminDataAccess().Search(p);
            if (data != null)
            {
                List<AdminModel> searchchk = new List<AdminModel>();
                foreach (var r in data)
                {
                    searchchk.Add(new AdminModel() 
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
