using System.Collections.Generic;
using static CloudBackend.Workers.ProfileController;

namespace CloudBackend.Models.Profile.Changes
{
    public class profileChanges
    {
        public string changeType { get; set; }
        public string _id { get; set; }
        public Profile profile { get; set; }
    }
}
