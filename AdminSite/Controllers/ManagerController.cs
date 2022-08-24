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
    public class ManagerController : ApiController
    {
        [HttpPost]
        [Route("api/admin/SearchManager")]
        public HttpResponseMessage SearchManager(ManagerModel u)
        {
            var data = ManagerService.Search(u.Name);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Not Found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/ManagerList/{id}")]
        [HttpGet]
        public HttpResponseMessage GetManager(int id)
        {
            var st = ManagerService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, st);
        }
        [Route("api/admin/ManagerList/")]
        [HttpGet]
        public HttpResponseMessage GetManager()
        {
            var ens = ManagerService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, ens);
        }
        [Route("api/admin/CreateManager/")]
        [HttpPost]
        public void AddManager(ManagerModel n)
        {
            ManagerService.Add(n);
        }
        [Route("api/admin/EditManager/")]
        [HttpPost]
        public void EditManager(ManagerModel n)
        {
            ManagerService.Edit(n);
        }
        [Route("api/Admin/DeleteManager/")]
        [HttpPost]
        public void DeleteManager(ManagerModel n)
        {
            ManagerService.Delete(n);
        }
    }
}
