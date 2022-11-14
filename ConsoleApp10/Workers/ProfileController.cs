using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CloudBackend.Workers.ProfileController;

namespace CloudBackend.Workers
{
    [Route("fortnite/api")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public static string profileIdOMG = "athena";
        public class QueryProfileModels
        {
            public int profileRevision { get; set; } = 1;
            public string profileId { get; set; } = profileIdOMG;
            public int profileChangesBaseRevision { get; set; } = 1;
            public string[] profileChanges { get; set; } = new string[0];
            public string serverTime { get; set; } = DateTime.Now.ToString("yyyy-MM-ddThh-mm-ssZ");
            public int profileCommandRevision { get; set; } = 1;
            public int responseVersion { get; set; } = 1;
        }
        [HttpPost("game/v2/profile/{AccountId}/client/QueryProfile")]
        [HttpPost("game/v2/profile/{AccountId}/client/SetMtxPlatform")]
        [HttpPost("game/v2/profile/{AccountId}/client/ClientQuestLogin")]
        public ActionResult<QueryProfileModels> QueryProfile([FromQuery] string profileId)
        {
            profileIdOMG = profileId;
            return new QueryProfileModels();
        }
    }
}
