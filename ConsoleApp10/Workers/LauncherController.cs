using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using System;

namespace CloudBackend.Workers
{
    [Route("launcher/api")]
    [ApiController]
    public class LauncherController: ControllerBase
    {
        public class distributionpointsmodules
        {
            public string[] distributions { get; set; } = new string[6] { "https://epicgames-download1.akamaized.net/", "https://download.epicgames.com/", "https://download2.epicgames.com/", "https://download3.epicgames.com/",  "https://download4.epicgames.com/", "https://fastly-download.epicgames.com/"};    
        }
        [HttpGet("public/distributionpoints")]
        public ActionResult<distributionpointsmodules> enabled_features(string ohno)
        {
            return new distributionpointsmodules();
        }
    }
}
