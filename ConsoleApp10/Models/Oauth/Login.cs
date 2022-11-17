namespace CloudBackend.Models.Oauth
{
    public class Login
    {
        public string access_token { get; set; } = Data.Saved.AccountId + "EWNAKID";
        public int expires_in { get; set; } = 28800;
        public string expires_at { get; set; } = "9999-12-31T23:59:59.999Z";
        public string token_type { get; set; } = "bearer";
        public string account_id { get; set; } = Data.Saved.AccountId;
        public string client_id { get; set; } = "ec684b8c687f479fadea3cb2ad83f5c6";
        public bool internal_client { get; set; } = true;
        public string client_service { get; set; } = "fortnite";
        public string displayName { get; set; } = Data.Saved.DisplayName;
        public string app { get; set; } = "fortnite";
        public string in_app_id { get; set; } = Data.Saved.AccountId;
        public string device_id { get; set; } = "5dcab5dbe86a7344b061ba57cdb33c4f";
    }
}
