using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CloudBackend.Errors.NotFound;
using static CloudBackend.Workers.LightswitchController;
using static System.Net.Mime.MediaTypeNames;

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
            public string eventType { get; set; } = $"EventFlag.LobbySeason{Data.Saved.FortniteSeasonYK}";
            public string activeUntil { get; set; } = "9999-12-31T23:59:59.999Z";
            public string activeSince { get; set; } = "2022-11-14T17:45:26.845Z";
        }
        public class clienteventactivestate
        {
            public string[] activeStorefronts { get; set;} = new string[0];
            public emptyyk eventNamedWeights { get; set; } = new emptyyk();
            public int seasonNumber { get; set; } = Data.Saved.FortniteSeasonYK;
            public string seasonTemplateId { get; set; } = $"AthenaSeason:athenaseason{Data.Saved.FortniteSeasonYK}";
            public int matchXpBonusPoints { get; set; } = 0;
            public string eventPunchCardTemplateId { get; set; } = "";
            public string seasonBegin { get; set; } = "9999-12-31T23:59:59.999Z";
            public string seasonEnd { get; set; } = "9999-12-31T23:59:59.999Z";
            public string seasonDisplayedEnd { get; set; } = "9999-12-31T23:59:59.999Z";
            public string weeklyStoreEnd { get; set; } = "9999-12-31T23:59:59.999Z";
            public string dailyStoreEnd { get; set; } = "9999-12-31T23:59:59.999Z";
            public string stwDailyStoreEnd { get; set; } = "9999-12-31T23:59:59.999Z";
            public string stwEventStoreEnd { get; set; } = "9999-12-31T23:59:59.999Z";
            public string stwWeeklyStoreEnd { get; set; } = "9999-12-31T23:59:59.999Z";
            public emptyyk sectionStoreEnds { get; set; } =  new emptyyk();
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
            string UserAgent = HttpContext.Request.Headers["User-Agent"];
            if (string.IsNullOrEmpty(UserAgent) || !UserAgent.Contains("Fortnite"))
            {
                Data.Saved.FortniteSeasonYK = 1;
            }
            else
            {
                try
                {
                    UserAgent = UserAgent.Split("-", StringSplitOptions.None)[1].Split(".")[0];
                    if (UserAgent == "Next" || UserAgent == "Cert" || UserAgent.Contains("+++Fortnite+Release"))
                    {
                        Data.Saved.FortniteSeasonYK = 2;
                    }
                    else
                    {
                        Data.Saved.FortniteSeasonYK = Int32.Parse(UserAgent);
                        Console.WriteLine(UserAgent);
                    }
                    Console.WriteLine(UserAgent);

                }
                catch
                {
                    Data.Saved.FortniteSeasonYK = 1;
                }
            }
            

            return new omg6923459343();
        }
    }
}
