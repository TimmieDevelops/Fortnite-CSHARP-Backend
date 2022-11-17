using System.Collections.Generic;
using System;
using static CloudBackend.Workers.ProfileController;

namespace CloudBackend.Models.Profile
{
    public class BlankQueryProfileAthenaModels
    {
        public int profileRevision { get; set; } = 1;
        public string profileId { get; set; } = profileIdOMG;
        public int profileChangesBaseRevision { get; set; } = 1;
        public List<object> profileChanges { get; set; }
        public string serverTime { get; set; } = DateTime.Now.ToString("yyyy-MM-ddThh-mm-ssZ");
        public int profileCommandRevision { get; set; } = 1;
        public int responseVersion { get; set; } = 1;
    }
}
