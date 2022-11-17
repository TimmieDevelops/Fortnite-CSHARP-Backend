using System;

namespace CloudBackend.Models.Oauth
{
    public class PublicAccountModels
    {
        public string id { get; set; } = Data.Saved.AccountId;
        public string displayName { get; set; } = Data.Saved.DisplayName;
        public string name { get; set; } = Data.Saved.DisplayName;
        public string email { get; set; } = Data.Saved.DisplayName + "@ohno.com";
        public int failedLoginAttempts { get; set; } = 0;
        public string lastLogin { get; set; } = DateTime.Now.ToString("yyyy-MM-ddThh-mm-ssZ");
        public int numberOfDisplayNameChanges { get; set; } = 0;
        public string ageGroup { get; set; } = "UNKNOWN";
        public bool headless { get; set; } = false;
        public string country { get; set; } = "US";
        public string lastName { get; set; } = "User";
        public string preferredLanguage { get; set; } = "en";
        public bool canUpdateDisplayName { get; set; } = false;
        public bool tfaEnabled { get; set; } = false;
        public bool emailVerified { get; set; } = true;
        public bool minorVerified { get; set; } = false;
        public bool minorExpected { get; set; } = false;
        public string minorStatus { get; set; } = "UNKNOWN";
    }
}
