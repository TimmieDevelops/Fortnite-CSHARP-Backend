using CloudBackend.Models.Lightswitch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CloudBackend.Workers.LightswitchController;

namespace CloudBackend.Workers
{
    [Route("[controller]/api/service/bulk/status")]
    [ApiController]
    public class LightswitchController : ControllerBase
    {
        public ActionResult<List<LightswitchStatus>> GetLightswitchStatus([FromQuery] string serviceId)
        {
            if (serviceId == null)
            {
                Data.Saved.serviceIdOmg = "Fortnite".ToLower();
            }
            else
            {
                Data.Saved.serviceIdOmg = serviceId.ToLower();
            }
            return new List<LightswitchStatus>
            {
                new LightswitchStatus()
            };
        }
    }
    [Route("/waitingroom/api/waitingroom")]
    public class WaitingRoom : ControllerBase
    {
        public ActionResult WaitingRoomE()
        {
            this.NoContent();
            return this.StatusCode(204);
        }
    }
    
}
