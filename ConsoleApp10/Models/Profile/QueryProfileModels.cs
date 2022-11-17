using static CloudBackend.Workers.ProfileController;
using System.Collections.Generic;
using System;
using CloudBackend.Models.Profile.Changes;

namespace CloudBackend.Models.Profile
{
    public class QueryProfileModels
    {
        public int profileRevision { get; set; } = 1;
        public string profileId { get; set; } = profileIdOMG;
        public int profileChangesBaseRevision { get; set; } = 1;
        public List<profileChanges> profileChanges { get; set; } = new List<profileChanges>();
        public string serverTime { get; set; } = DateTime.Now.ToString("yyyy-MM-ddThh-mm-ssZ");
        public int profileCommandRevision { get; set; } = 1;
        public int responseVersion { get; set; } = 1;
    }
}
