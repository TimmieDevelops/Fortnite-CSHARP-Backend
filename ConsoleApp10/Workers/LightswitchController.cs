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
        public class launcherInfoDTO
        {
            public string appName { get; set; } = "Fortnite";
            public string catalogItemId { get; set; } = "4fe75bbc5a674f4f9b356b5c90567da5";

            [JsonProperty("namespace")]
            public string Namespace { get; set; } = "fn";
        }
        public class LightswitchStatus
        {
            public string serviceInstanceId { get; set; } = Data.Saved.serviceIdOmg;
            public string status { get; set; } = "UP";
            public string message { get; set; } = "servers up.";
            public string maintenanceUri { get; set; } = "https://ohno.com";
            public string[] overrideCatalogIds { get; set; } = new string[1] { "a7f138b2e51945ffbfdacc1af0541053" };
            public string[] allowedActions { get; set; } = new string[2] { "PLAY", "DOWNLOAD" };
            public bool banned { get; set; } = false;
            public launcherInfoDTO launcherInfoDTO { get; set; } = new launcherInfoDTO();
        }
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
