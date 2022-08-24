using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;
using BLL.BusinessEntity;
using System.Web.Http.Cors;

namespace AdminSite.Controllers
{
    public class UserController : ApiController
    {

        [HttpPost]
        [Route("api/admin/login")]
        public HttpResponseMessage Login(AdminModel u)
        {
            var data = UserService.Authenticate(u.Email, u.Password);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Username Or Password Invalid");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/admin/logout/{uid}")]
        public HttpResponseMessage Logout(int uid)
        {
            var data = UserService.Logout(uid);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully Logged Out");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Already Loggedout");
        }

    }
}
