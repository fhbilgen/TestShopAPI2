using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestShopAPI2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OuterRim : ControllerBase
    {
        private readonly ILogger<OuterRim> _logger;
        private static Random r = new Random();

        public OuterRim(ILogger<OuterRim> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<int> LongExecution()
        {
            System.Threading.Thread.Sleep(50000);
            return 50000;
        }

        [HttpGet]
        public ActionResult<int> RandomExecution()
        {
            var i = r.Next(1000);
            System.Threading.Thread.Sleep(i);
            
            return i;
        }
    }

}
