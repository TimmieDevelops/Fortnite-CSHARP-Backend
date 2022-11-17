using CloudBackend.Models.Launcher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using System;

namespace CloudBackend.Workers
{
    [Route("launcher/api")]
    [ApiController]
    public class LauncherController: ControllerBase
    {
        [HttpGet("public/distributionpoints")]
        public ActionResult<DistributionPointsModules> enabled_features(string ohno)
        {
            return new DistributionPointsModules();
        }
    }
}
