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
    public class EntrepreneurController : ApiController
    {
        [HttpPost]
        [Route("api/admin/SearchEnt")]
        public HttpResponseMessage SearchEnt(EntrepreneurModel u)
        {
            var data = EntrepreneurService.Search(u.Name);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Not Found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/EntList/{id}")]
        [HttpGet]
        public HttpResponseMessage GetEnt(int id)
        {
            var st = EntrepreneurService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, st);
        }
        [Route("api/admin/EntList")]
        [HttpGet]
        public HttpResponseMessage EntList()
        {
            var ens = EntrepreneurService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, ens);
        }
        [Route("api/admin/CreateEnt/")]
        [HttpPost]
        public void AddEnt(EntrepreneurModel n)
        {
            EntrepreneurService.Add(n);
        }
        [Route("api/admin/EditEnt/")]
        [HttpPost]
        public void EditEnt(EntrepreneurModel n)
        {
            EntrepreneurService.Edit(n);
        }
        [Route("api/Admin/DeleteEnt")]
        [HttpPost]
        public void DeleteEnt(EntrepreneurModel n)
        {
            EntrepreneurService.Delete(n);
        }
    }
}
