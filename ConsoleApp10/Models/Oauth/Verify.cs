namespace CloudBackend.Models.Oauth
{
    public class Verify
    {
        public string token { get; set; } = Data.Saved.AccountId;
        public string session_id { get; set; } = "3c3662bcb661d6de679c636744c66b62";
        public string token_type { get; set; } = "bearer";
        public bool internal_client { get; set; } = true;
        public string client_service { get; set; } = "fortnite";
        public string account_id { get; set; } = Data.Saved.AccountId;
        public int expires_in { get; set; } = 28800;
        public string expires_at { get; set; } = "9999-12-02T01:12:01.100Z";
        public string auth_method { get; set; } = "exchange_code";
        public string display_name { get; set; } = Data.Saved.DisplayName;
        public string app { get; set; } = "fortnite";
        public string in_app_id { get; set; } = Data.Saved.AccountId;
        public string device_id { get; set; } = Data.Saved.AccountId;
    }
}
