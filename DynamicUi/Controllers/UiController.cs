using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
namespace DynamicUi.Controllers
{
    public class UiController : ApiController
    {
        public IHttpActionResult Get()
        {
            TestUi ts = new TestUi();
            return Ok(ts.buildPage());
        }
        public IHttpActionResult Get2()
        {
            TestUi ts = new TestUi();
            return Ok(ts.buildPage2());
        }
        public IHttpActionResult Getx1()
        {
            TestUi ts = new TestUi();
            return Ok(ts.buildPage3());
        }
        public IHttpActionResult Getx2()
        {
            TestUi ts = new TestUi();
            return Ok(ts.buildPage4());
        }
        public IHttpActionResult Getx3()
        {
            Bootstrap b = new Bootstrap();
            return Ok(b);
        }
    }
}
