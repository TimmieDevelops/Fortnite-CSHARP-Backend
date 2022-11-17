namespace CloudBackend.Models.Profile.Changes
{
    public class Stats
    {
        public Attributes attributes { get; set; }
    }
    public class Attributes
    {
        public string[] past_seasons { get; set; } = new string[0];
        public int season_match_boost { get; set; } = 999999999;
        public string[] loadouts { get; set; } = new string[2] { "sandbox_loadout", "loadout_1" };
        public string favorite_victorypose { get; set; } = "";
        public bool mfa_reward_claimed { get; set; } = false;
        public int book_level { get; set; } = 70;
        public int season_num { get; set; } = 2;
        public string favorite_consumableemote { get; set; } = "";
        public int book_xp { get; set; } = 100;
        public bool book_purchased { get; set; } = false; // or you will maybe get stw
        public int lifetime_wins { get; set; } = 100;
        public string favorite_callingcard { get; set; } = Data.Saved.favorite_callingcard;
        public string favorite_character { get; set; } = Data.Saved.favorite_character;
        public string[] favorite_spray { get; set; } = Data.Saved.favorite_spray;
        public string favorite_loadingscreen { get; set; } = Data.Saved.favorite_loadingscreen;
        public string favorite_hat { get; set; } = Data.Saved.favorite_hat;
        public string favorite_battlebus { get; set; } = Data.Saved.favorite_battlebus;
        public string favorite_mapmarker { get; set; } = Data.Saved.favorite_mapmarker;
        public string favorite_vehicledeco { get; set; } = Data.Saved.favorite_vehicledeco;
        public int accountLevel { get; set; } = 100;
        public string favorite_backpack { get; set; } = Data.Saved.favorite_backpack;
        public int inventory_limit_bonus { get; set; } = 0;
        public string last_applied_loadout { get; set; } = "";
        public string ast_applied_loadout { get; set; } = "sandbox_loadout";
        public string favorite_skydivecontrail { get; set; } = Data.Saved.favorite_skydivecontrail;
        public string favorite_pickaxe { get; set; } = Data.Saved.favorite_pickaxe;
        public string favorite_glider { get; set; } = Data.Saved.favorite_glider;
        public int xp { get; set; } = 999;
        public int season_friend_match_boost { get; set; } = 999999999;
        public int intactive_loadout_index { get; set; } = 0;
        public string favorite_musicpack { get; set; } = Data.Saved.favorite_musicpack;
        public string banner_color { get; set; } = Data.Saved.banner_color;
        public string banner_icon { get; set; } = Data.Saved.banner_icon;
        public string[] favorite_dance { get; set; } = Data.Saved.favorite_dance;
        public string[] favorite_itemwraps { get; set; } = Data.Saved.favorite_itemwraps;
    }
}
