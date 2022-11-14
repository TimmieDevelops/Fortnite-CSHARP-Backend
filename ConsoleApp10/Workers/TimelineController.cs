using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CloudBackend.Workers.LightswitchController;

namespace CloudBackend.Workers
{
    [Route("fortnite/api/calendar/v1/timeline")]
    [ApiController]
    public class TimelineController : ControllerBase
    {
        public class emptyyk
        {

        }
        public class omg692345934
        {
            public string[] activePurchaseLimitingEventIds { get; set; } = new string[0];
            public emptyyk storefront { get; set; } = new emptyyk();
            public string[] rmtPromotionConfig { get; set; } = new string[0];
            public string storeEnd { get; set; } = "0001-01-01T00:00:00.000Z";
        }
        public class omg692345934934
        {
            public string validFrom { get; set; } = "9999-10-23T12:30:37.146Z";
            public string[] activeEvents { get; set; } = new string[0];
            public omg692345934 state { get; set; } = new omg692345934();
        }
        public class omg69234593493
        {
            public List<omg692345934934> states { get; set; } = new List<omg692345934934> {
                new omg692345934934()
            };
            public string cacheExpire { get; set; } = "9999-10-23T14:30:37.146Z";
        }
        public class clienteventactiveevents
        {
            
        }
        public class clienteventactivestate
        {

        }
        public class clienteventstates
        {
            public string validFrom { get; set; } = "2019-05-21T18:36:38.383Z";
            public List<clienteventactiveevents> activeEvents { get; set; } = new List<clienteventactiveevents>
            {
                new clienteventactiveevents()
            };
            public clienteventactivestate state { get; set; } = new clienteventactivestate();
        }
        public class omg69234545
        {
            public List<clienteventstates> states { get; set; } = new List<clienteventstates> { 
                new clienteventstates()
            };
            public string cacheExpire { get; set; } = "9999-10-23T14:30:37.146Z";
        }
        public class omg6923459349
        {
            [JsonPropertyName("standalone-store")]
            public omg69234593493 standalonestore { get; set; } = new omg69234593493();

            [JsonPropertyName("client-events")]
            public omg69234545 clientevents { get; set; } = new omg69234545();
            
        }
        public class omg6923459343
        {
            public omg6923459349 channels { get; set; } = new omg6923459349();
            public int cacheIntervalMins { get; set; } = 15;
            public string currentTime { get; set; } = DateTime.Now.ToString("yyyy-MM-ddThh-mm-ssZ");
        }

        public ActionResult<omg6923459343> Timeline()
        {
            return new omg6923459343();
        }
    }
}
