namespace CloudBackend.Models.Launcher
{
    public class DistributionPointsModules
    {
        public string[] distributions { get; set; } = new string[6] { 
            "https://epicgames-download1.akamaized.net/", 
            "https://download.epicgames.com/", 
            "https://download2.epicgames.com/", 
            "https://download3.epicgames.com/",
            "https://download4.epicgames.com/", 
            "https://fastly-download.epicgames.com/" 
        };
    }
}
