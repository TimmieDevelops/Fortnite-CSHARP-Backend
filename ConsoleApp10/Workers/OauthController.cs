using CloudBackend.Models.Oauth;
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
        [HttpGet("oauth/verify")]
        public ActionResult<Verify> VerifyOAuthToken()
        {
            return new Verify();
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
       

        [HttpGet("public/account/{accountID}")]
        public ActionResult<PublicAccountModels> PublicAccountOMG(string accountID)
        {
            Data.Saved.AccountId = accountID;   
            return new PublicAccountModels();
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
