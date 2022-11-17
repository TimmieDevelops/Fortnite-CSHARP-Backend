using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CloudBackend.Workers.VerifyController;

namespace CloudBackend.Workers
{
    [Route("account/api")]
    [ApiController]
    public class VerifyController: ControllerBase
    {
        public class emptyyk
        {

        }
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

        [HttpGet("oauth/verify")]
        public ActionResult<Verify> VerifyOAuthToken()
        {
            return new Verify();
        }
    


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
        [HttpPost("oauth/token")]
        public ActionResult<Login> LoginOAuthToken([FromForm] string grant_type)
        {
            try
            {
                IFormCollection form = base.Request.Form;
                if (grant_type == "password")
                {
                    Data.Saved.DisplayName = form["username"].ToString().Split("@", StringSplitOptions.None)[0];
                }
                //  if(grant_type == "client_credentials")
                //  {
                //     Data.LoginDetails.DisplayName = null;
                //      Data.LoginDetails.AccountId = null;
                // }
                // if(grant_type == "exchange_code")
                //  {
                //    Data.LoginDetails.DisplayName = form["exchange_code"].ToString();
                //  Data.LoginDetails.AccountId = form["exchange_code"].ToString();
                // }

                return new Login();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Login();
            }
        }

        [HttpDelete("oauth/sessions/kill")]
        [HttpDelete("oauth/sessions/kill/{accessToken}")]
        public ActionResult KillSession(string accessToken)
        {
            return this.NoContent();
        }
        

    
    
            public class Epics
            {
                public string id { get; set; } = Data.Saved.AccountId;
                public string displayName { get; set; } = Data.Saved.DisplayName;
                public string name { get; set; } = Data.Saved.DisplayName;
                public string email { get; set; } = Data.Saved.DisplayName + "@ohno.com";
                public int failedLoginAttempts { get; set; } = 0;
                public string lastLogin { get; set; } = DateTime.Now.ToString("yyyy-MM-ddThh-mm-ssZ");
                public int numberOfDisplayNameChanges { get; set; } = 0;
                public string ageGroup { get; set; } = "UNKNOWN";
                public bool headless { get; set; } = false;
                public string country { get; set; } = "US";
                public string lastName { get; set; } = "User";
                public string preferredLanguage { get; set; } = "en";
                public bool canUpdateDisplayName { get; set; } = false;
                public bool tfaEnabled { get; set; } = false;
                public bool emailVerified { get; set; } = true;
                public bool minorVerified { get; set; } = false;
                public bool minorExpected { get; set; } = false;
                public string minorStatus { get; set; } = "UNKNOWN";
            }

            [HttpGet("public/account/{accountID}")]
            public ActionResult<Epics> PublicAccountOMG(string accountID)
            {
                Data.Saved.AccountId = accountID;   
                return new Epics();
            }

            public class AccountModelTHingy
            {
                public string id { get; set; } = Data.Saved.AccountId;
                public string displayName { get; set; } = Data.Saved.DisplayName;
                public emptyyk externalAuths { get; set; } = new emptyyk();
            }

            [HttpGet("epicdomains/ssodomains")]
            public ActionResult<string[]> ssodomains(string accessToken)
            {
                return new string[4] { "unrealengine.com", "unrealtournament.com", "fortnite.com", "epicgames.com" };
            }
            [HttpGet("public/account")]
            public ActionResult<List<AccountModelTHingy>> accounts([FromQuery] string accountId)
            {
                return new List<AccountModelTHingy>()
                {
                    new AccountModelTHingy()
                };
            }

            [HttpGet("account/api/public/account/{accountId}/externalAuths")]
            public ActionResult<object> externalAuths(string accessToken)
            {
                return new object();
            }
        
    }



}
