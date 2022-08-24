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
    public class AdminController : ApiController
    {
        [HttpPost]
        [Route("api/admin/SearchAdmin")]
        public HttpResponseMessage SearchAdmin(AdminModel u)
        {
            var data = AdminService.Search(u.Name);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Not Found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [Route("api/admin/AdminList/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var st = AdminService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, st);
        }
        [Route("api/admin/AdminList/")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var ens = AdminService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, ens);
        }
        [Route("api/admin/CreateAdmin")]
        [HttpPost]
        public void AddAdmin(AdminModel n)
        {
            AdminService.Add(n);
        }

        [Route("api/admin/EditAdmin")]
        [HttpPost]
        public void EditAdmin(AdminModel n)
        {
            AdminService.Edit(n);
        }

        [Route("api/Admin/DeleteAdmin/")]
        [HttpPost]
        public void DeleteAdmin(AdminModel n)
        {
            AdminService.Delete(n);
        }


    }
}
