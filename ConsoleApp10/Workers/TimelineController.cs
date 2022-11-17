using CloudBackend.Models.Timeline;
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
        public ActionResult<TimeLineModels> Timeline()
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

            return new TimeLineModels();
        }
    }
}
