using static CloudBackend.Workers.TimelineController;
using System.Text.Json.Serialization;
using CloudBackend.Models.Timeline.Channels.Clientevents;
using CloudBackend.Models.Timeline.Channels.Standalonestore;

namespace CloudBackend.Models.Timeline.Channels
{
    public class Channel
    {
        [JsonPropertyName("standalone-store")]
        public Standalone_Store standalonestore { get; set; } = new Standalone_Store();

        [JsonPropertyName("client-events")]
        public Client_Event clientevents { get; set; } = new Client_Event();
    }
}
