using CloudBackend.Data;
using System.Collections.Generic;


namespace CloudBackend.Models.Timeline.Channels.Clientevents
{
    public class Client_Event
    {
        public List<Clienteventstates> states { get; set; } = new List<Clienteventstates> {
            new Clienteventstates()
        };
        public string cacheExpire { get; set; } = "9999-10-23T14:30:37.146Z";
    }

    public class Clienteventstates
    {
        public string validFrom { get; set; } = "2019-05-21T18:36:38.383Z";
        public List<Clienteventactiveevents> activeEvents { get; set; } = new List<Clienteventactiveevents>
            {
                new Clienteventactiveevents()
            };
        public Clienteventactivestate state { get; set; } = new Clienteventactivestate();
    }

    public class Clienteventactiveevents
    {
        public string eventType { get; set; } = $"EventFlag.LobbySeason{Data.Saved.FortniteSeasonYK}";
        public string activeUntil { get; set; } = "9999-12-31T23:59:59.999Z";
        public string activeSince { get; set; } = "2022-11-14T17:45:26.845Z";
    }

    public class Clienteventactivestate
    {
        public string[] activeStorefronts { get; set; } = new string[0];
        public empty eventNamedWeights { get; set; } = new empty();
        public int seasonNumber { get; set; } = Data.Saved.FortniteSeasonYK;
        public string seasonTemplateId { get; set; } = $"AthenaSeason:athenaseason{Data.Saved.FortniteSeasonYK}";
        public int matchXpBonusPoints { get; set; } = 0;
        public string eventPunchCardTemplateId { get; set; } = "";
        public string seasonBegin { get; set; } = "9999-12-31T23:59:59.999Z";
        public string seasonEnd { get; set; } = "9999-12-31T23:59:59.999Z";
        public string seasonDisplayedEnd { get; set; } = "9999-12-31T23:59:59.999Z";
        public string weeklyStoreEnd { get; set; } = "9999-12-31T23:59:59.999Z";
        public string dailyStoreEnd { get; set; } = "9999-12-31T23:59:59.999Z";
        public string stwDailyStoreEnd { get; set; } = "9999-12-31T23:59:59.999Z";
        public string stwEventStoreEnd { get; set; } = "9999-12-31T23:59:59.999Z";
        public string stwWeeklyStoreEnd { get; set; } = "9999-12-31T23:59:59.999Z";
        public empty sectionStoreEnds { get; set; } = new empty();
    }
}

