
using System.Collections.Generic;

namespace CloudBackend.Models.Profile.Changes
{
    public class Profile
    {
        public string _id { get; set; }
        public string Update { get; set; }
        public string Created { get; set; } = "2021-03-07T16:33:28.462Z";
        public string updated { get; set; } = "2021-05-20T14:57:29.907Z";
        public int rvn { get; set; } = 0;
        public int wipeNumber { get; set; } = 1;
        public string accountId { get; set; }
        public string profileId { get; set; }
        public string version { get; set; } = "no_version";
        public Dictionary<string, object> items { get; set; }
        public Stats stats { get; set; } = new Stats();
        public int commandRevision { get; set; } = 5;
    }
}
