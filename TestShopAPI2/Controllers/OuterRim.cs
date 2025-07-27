using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestShopAPI2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OuterRim : ControllerBase
    {
        private static List<string> _messages = new List<string>
        {
            "Outer Rim is a remote area of the galaxy, far from the core worlds.",
            "It is known for its lawlessness and the presence of various alien species.",
            "The Outer Rim Territories are often explored by smugglers and adventurers.",
            "Many planets in the Outer Rim are rich in resources but lack proper governance."
        };
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

        [HttpGet]
        public ActionResult<int> GrowTheStory()
        {
            for (int i = 0; i < 1000; i++)
            {
                _messages.Add("A new story has been added to the Outer Rim lore.");
                _messages.Add("The Outer Rim is becoming a hub for intergalactic trade.");
                _messages.Add("Adventurers are flocking to the Outer Rim in search of fame and fortune.");
                _messages.Add("The Outer Rim is home to many mysterious and ancient artifacts.");
            }

            return _messages.Count;

        }
    }

}
