using System.Web.Http;
using DynamicUi.App_Start;
using DynamicUi.dddd;
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
            return Ok(b.buildBS1());
        }
        public IHttpActionResult Getx4()
        {
            Bootstrap b = new Bootstrap();
            return Ok(b.buildBS2());
        }
        public IHttpActionResult Getx5()
        {
            Bootstrap b = new Bootstrap();
            return Ok(b.buildBS3());
        }
        public IHttpActionResult Getx6()
        {
            Builder b = new Builder();
            return Ok(b.create1());
        }
        public IHttpActionResult Getx7()
        {
            Builder b = new Builder();
            return Ok(b.create2());
        }
        public IHttpActionResult Getx8()
        {
            Builder b = new Builder();
            return Ok(b.create3());
        }
        public IHttpActionResult Getmb1()
        {
            BmBuilder bm = new BmBuilder();
            return Ok(bm.build1());
        }
        public IHttpActionResult Getmb2()
        {
            BmBuilder bm = new BmBuilder();
            return Ok(bm.build2());
        }
    }
}
