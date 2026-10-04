using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CatchAll.Controllers
{
    [Route("{**catchAll}")]
    public class CatchAllController : ApiController
    {
        [AcceptVerbs("GET", "POST", "PUT", "PATCH", "DELETE", "HEAD", "OPTIONS", "TRACE", "CONNECT")]
        public async Task<IHttpActionResult> CatchAll()
        {
            var route = HttpContext.Current.Request.CurrentExecutionFilePath;

            //if a specific querystring parameter is specified, return special data
            // http://localhost/CatchAllAPI/demo/route?dummyparam=1
            if (HttpContext.Current.Request.QueryString["dummyparam"] == "1")
            {
                var resultJson = new System.Web.Mvc.JsonResult
                {
                    Data = new { Numberrr = 111, Texttt = "xxxyyyzzz", Boooolean = true, Arrrray = new int[] { 1, 2, 3, 4, 5 } }
                };
                return Ok(resultJson.Data);
            }
            // http://localhost/CatchAllAPI/dummyjson/other?dummyparam=1
            if (route.Contains("dummyjson"))
            {
                return Ok(new System.Web.Mvc.JsonResult { Data = new { Example = "123456789" } }.Data);
            }
            // read post body
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (HttpContext.Current.Request.ContentLength > 0)
                {
                    //read posted contents into variable
                    HttpContext.Current.Request.InputStream.Position = 0;
                    var rawRequestBody = new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd();
                }
            }

            return base.Ok();
        }
    }
}