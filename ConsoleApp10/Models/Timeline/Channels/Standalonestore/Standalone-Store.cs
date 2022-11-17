using CloudBackend.Data;

namespace CloudBackend.Models.Timeline.Channels.Standalonestore
{
    public class Standalone_Store
    {
        public string validFrom { get; set; } = "9999-10-23T12:30:37.146Z";
        public string[] activeEvents { get; set; } = new string[0];
        public State state { get; set; } = new State();
    }

    public class State
    {
        public string[] activePurchaseLimitingEventIds { get; set; } = new string[0];
        public empty storefront { get; set; } = new empty();
        public string[] rmtPromotionConfig { get; set; } = new string[0];
        public string storeEnd { get; set; } = "0001-01-01T00:00:00.000Z";
    }
}
