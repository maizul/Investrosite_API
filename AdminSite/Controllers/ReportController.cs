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
    public class ReportController : ApiController
    {
        [UserAuth]
        [Route("api/admin/ReportList")]
        [HttpGet]
        public HttpResponseMessage GetReport()
        {
            var ens = ReportService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, ens);
        }

        [Route("api/CreateReport")]
        [HttpPost]
        public void AddReport(ReportModel n)
        {
            ReportService.Add(n);
        }
    }

}
