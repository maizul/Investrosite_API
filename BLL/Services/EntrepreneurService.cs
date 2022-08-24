using BLL.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Database;
using DAL.Repo;
using AutoMapper;

namespace BLL.Services
{
    public class EntrepreneurService
    {
        public static EntrepreneurModel Get(int id)
        {
            var en = DataAccessFactory.EntrepreneurDataAccess().Get(id);
            var s = new EntrepreneurModel()
            {
                Id = en.Id,
                Name = en.Name,
                Email = en.Email,
                Phone = en.Phone,
                Password = en.Password,
                Role = en.Role
            };
            return s;

        }
        public static List<EntrepreneurModel> Get()
        {
            var ens = DataAccessFactory.EntrepreneurDataAccess().Get();
            List<EntrepreneurModel> data = new List<EntrepreneurModel>();
            foreach (var s in ens)
            {
                data.Add(new EntrepreneurModel() { Id = s.Id, Name = s.Name, Email = s.Email, Password = s.Password, Phone = s.Phone, Role = s.Role });

            }
            return data;

        }
        public static void Add(EntrepreneurModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap< EntrepreneurModel, Entrepreneur>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Entrepreneur>(p);
            DataAccessFactory.EntrepreneurDataAccess().Add(data);
        }
        public static void Edit(EntrepreneurModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<EntrepreneurModel, Entrepreneur>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Entrepreneur>(p);
            DataAccessFactory.EntrepreneurDataAccess().Edit(data);
        }
        
        public static void Delete(EntrepreneurModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<EntrepreneurModel, Entrepreneur>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Entrepreneur>(p);
            DataAccessFactory.EntrepreneurDataAccess().Delete(data);
        }

        public static List<EntrepreneurModel> Search(string p)
        {
            var data = DataAccessFactory.EntrepreneurDataAccess().Search(p);
            if (data != null)
            {
                List<EntrepreneurModel> searchchk = new List<EntrepreneurModel>();
                foreach (var r in data)
                {
                    searchchk.Add(new EntrepreneurModel()
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
