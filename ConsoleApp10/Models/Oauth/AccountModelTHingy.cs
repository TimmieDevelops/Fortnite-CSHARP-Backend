using CloudBackend.Data;

namespace CloudBackend.Models.Oauth
{
    public class AccountModelTHingy
    {
        public string id { get; set; } = Data.Saved.AccountId;
        public string displayName { get; set; } = Data.Saved.DisplayName;
        public empty externalAuths { get; set; } = new empty();
    }
}
