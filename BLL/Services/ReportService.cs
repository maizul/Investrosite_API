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
    public class ReportService
    {
        public static ReportModel Get(int id)
        {
            var req = DataAccessFactory.ReportDataAccess().Get(id);
            var s = new ReportModel()
            {
                Id = req.Id,
                Name = req.Name,
                Email = req.Email,
                Issue = req.Issue
            };
            return s;

        }
        public static List<ReportModel> Get()
        {
            var reqs = DataAccessFactory.ReportDataAccess().Get();
            List<ReportModel> data = new List<ReportModel>();
            foreach (var r in reqs)
            {
                data.Add(new ReportModel() { Id = r.Id, Name = r.Name, Email = r.Email, Issue = r.Issue });

            }
            return data;

        }
        public static void Add(ReportModel p)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ReportModel, Report>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Report>(p);
            DataAccessFactory.ReportDataAccess().Add(data);
        }

    }
}
