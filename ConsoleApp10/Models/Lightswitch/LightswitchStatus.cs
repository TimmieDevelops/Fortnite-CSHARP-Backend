namespace CloudBackend.Models.Lightswitch
{
    public class LightswitchStatus
    {
        public string serviceInstanceId { get; set; } = Data.Saved.serviceIdOmg;
        public string status { get; set; } = "UP";
        public string message { get; set; } = "servers up.";
        public string maintenanceUri { get; set; } = "https://ohno.com";
        public string[] overrideCatalogIds { get; set; } = new string[1] { "a7f138b2e51945ffbfdacc1af0541053" };
        public string[] allowedActions { get; set; } = new string[2] { "PLAY", "DOWNLOAD" };
        public bool banned { get; set; } = false;
        public launcherInfoDTO launcherInfoDTO { get; set; } = new launcherInfoDTO();
    }
}
