using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;
using BLL.BusinessEntity;
using AdminSite.Auth;
using System.Web.Http.Cors;
namespace AdminSite.Controllers
{
    [UserAuth]
    public class InvestorController : ApiController
    {
        [HttpPost]
        [Route("api/admin/SearchInv")]
        public HttpResponseMessage SearchInv(InvestorModel u)
        {
            var data = InvestorService.Search(u.Name);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Not Found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/InvestorList/{id}")]
        [HttpGet]
        public HttpResponseMessage GetInvestor(int id)
        {
            var st = InvestorService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, st);
        }
        [Route("api/Admin/InvestorList")]
        [HttpGet]
        public HttpResponseMessage GetInvestor()
        {
            var ens = InvestorService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, ens);
        }
        [Route("api/admin/CreateInvestor/")]
        [HttpPost]
        public void AddInvestor(InvestorModel n)
        {
            InvestorService.Add(n);
        }
        [Route("api/admin/EditInvestor/")]
        [HttpPost]
        public void EditInvestor(InvestorModel n)
        {
            InvestorService.Edit(n);
        }
        [Route("api/Admin/DeleteInvestor")]
        [HttpPost]
        public void DeleteInvestor(InvestorModel n)
        {
            InvestorService.Delete(n);
        }
    }
}
