using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CatchAll.Controllers
{
    public class CatchAllController : ApiController
    {
        private async Task<IHttpActionResult> ProcessAny()
        {
            var route = HttpContext.Current.Request.CurrentExecutionFilePath;
            // http://localhost/catchall/demo/route?dummyparam=1
            if (HttpContext.Current.Request.QueryString["dummyparam"] == "1")
            {
                var resultJson = new System.Web.Mvc.JsonResult
                {
                    Data = new { Numberrr = 111, Texttt = "xxxyyyzzz", Boooolean = true, Arrrray = new int[] { 1, 2, 3, 4, 5 } }
                };
                return Ok(resultJson.Data);
            }
            // http://localhost/catchall/dummyjson/other?dummyparam=1
            if (route.Contains("dummyjson/"))
            {
                return Ok(new System.Web.Mvc.JsonResult { Data = new { Example = "123456789" } }.Data);
            }
            return base.Ok();
        }

        [Route("{**catchAll}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return await ProcessAny();
            }
            catch
            {
                return base.InternalServerError();
            }
        }

        [Route("{**catchAll}")]
        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            try
            {
                if (HttpContext.Current.Request.ContentLength > 0)
                {
                    //read posted contents into variable
                    HttpContext.Current.Request.InputStream.Position = 0;
                    var rawRequestBody = new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd();
                }
                return await ProcessAny();
            }
            catch
            {
                return base.InternalServerError();
            }
        }

        [Route("{**catchAll}")]
        [HttpPut]
        public async Task<IHttpActionResult> Put()
        {
            try
            {
                return await ProcessAny();
            }
            catch
            {
                return base.InternalServerError();
            }
        }

        [Route("{**catchAll}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete()
        {
            try
            {
                return await ProcessAny();
            }
            catch
            {
                return base.InternalServerError();
            }
        }
    }
}