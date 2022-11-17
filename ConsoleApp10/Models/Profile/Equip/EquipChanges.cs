
using System.Collections.Generic;
using System;

namespace CloudBackend.Models.Profile.Equip
{
    public class EquipChanges
    {
        public int profileRevision { get; set; } = Data.Saved.profilerevision;
        public string profileId { get; set; } = "athena";
        public int profileChangesBaseRevision { get; set; } = Data.Saved.profilerevision;
        public List<profileChangesCode> profileChanges { get; set; }
        public int profileCommandRevision { get; set; } = Data.Saved.profilerevision;
        public string serverTime { get; set; } = DateTime.Now.ToString("yyyy-MM-ddThh-mm-ssZ");
        public int responseVersion { get; set; } = 2;
    }

    public class profileChangesCode
    {
        public string changeType { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
}
