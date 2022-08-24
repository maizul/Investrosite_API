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
    public class PaymentController : ApiController
    {
        [UserAuth]
        [Route("api/admin/Payment/")]
        [HttpGet]
        public HttpResponseMessage GetPayment()
        {
            var payment = PaymentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, payment);
        }
    }
}
