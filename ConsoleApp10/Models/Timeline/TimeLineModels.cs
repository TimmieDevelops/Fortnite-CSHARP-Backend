using System;
using CloudBackend.Models.Timeline.Channels;

namespace CloudBackend.Models.Timeline
{
    public class TimeLineModels
    {
        public Channel channels { get; set; } = new Channel();
        public int cacheIntervalMins { get; set; } = 15;
        public string currentTime { get; set; } = DateTime.Now.ToString("yyyy-MM-ddThh-mm-ssZ");
    }
}
