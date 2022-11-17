using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static CloudBackend.Workers.ProfileController;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace CloudBackend.Workers
{
    [Route("fortnite/api")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public static string profileIdOMG = "athena";
        public class QueryProfileModels
        {
            public int profileRevision { get; set; } = 1;
            public string profileId { get; set; } = profileIdOMG;
            public int profileChangesBaseRevision { get; set; } = 1;
            public string[] profileChanges { get; set; } = new string[0];
            public string serverTime { get; set; } = DateTime.Now.ToString("yyyy-MM-ddThh-mm-ssZ");
            public int profileCommandRevision { get; set; } = 1;
            public int responseVersion { get; set; } = 1;
        }
        public class attributes69
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
        public class fdsfsdsddffsd
        {
            public attributes69 attributes { get; set; }
        }
        public class profileomgss
        {
            public string _id { get; set; }
            public string Update { get; set; }
            public string Created { get; set; } = "2021-03-07T16:33:28.462Z";
            public string updated { get; set; } = "2021-05-20T14:57:29.907Z";
            public int rvn { get; set; } = 0;
            public int wipeNumber { get; set; } = 1;
            public string accountId { get; set; }
            public string profileId { get; set; }
            public string version { get; set; } = "no_version";
            public Dictionary<string, object> items { get; set; }
            public fdsfsdsddffsd stats { get; set; } = new fdsfsdsddffsd();
            public int commandRevision { get; set; } = 5;
        }
        public class profileChanges23
        {
            public string changeType { get; set; }

            public string _id { get; set; }
            public profileomgss profile { get; set; }
        }
        public class BlankQueryProfileAthenaModels
        {
            public int profileRevision { get; set; } = 1;
            public string profileId { get; set; } = profileIdOMG;
            public int profileChangesBaseRevision { get; set; } = 1;
            public List<object> profileChanges { get; set; }
            public string serverTime { get; set; } = DateTime.Now.ToString("yyyy-MM-ddThh-mm-ssZ");
            public int profileCommandRevision { get; set; } = 1;
            public int responseVersion { get; set; } = 1;
        }
        public class QueryProfileAthenaModels
        {
            public int profileRevision { get; set; } = 1;
            public string profileId { get; set; } = profileIdOMG;
            public int profileChangesBaseRevision { get; set; } = 1;
            public List<profileChanges23> profileChanges { get; set; } = new List<profileChanges23>();
            public string serverTime { get; set; } = DateTime.Now.ToString("yyyy-MM-ddThh-mm-ssZ");
            public int profileCommandRevision { get; set; } = 1;
            public int responseVersion { get; set; } = 1;
        }

 
        [HttpPost("game/v2/profile/{AccountId}/client/QueryProfile")]
        [HttpPost("game/v2/profile/{AccountId}/client/SetMtxPlatform")]
        [HttpPost("game/v2/profile/{AccountId}/client/ClientQuestLogin")]
        public ActionResult<QueryProfileAthenaModels> QueryProfile([FromQuery] string profileId)
        {
            if (profileId == "athena")
            {
               
                profileIdOMG = profileId;
                JArray values = JArray.Parse(System.IO.File.ReadAllText(Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), $"resources/json/athena.json")));

                var itemsFormatted = new Dictionary<string, object>();
                itemsFormatted.Add("sandbox_loadout", new
                {
                    templateId = "CosmeticLocker:cosmeticlocker_athena",
                    attributes = new
                    {
                        locker_slots_data = new
                        {
                            slots = new
                            {
                                MusicPack = new
                                {
                                    items = new string[1] { Data.Saved.favorite_musicpack },
                                },
                                Character = new
                                {
                                    items = new string[1] { Data.Saved.favorite_character },
                                    activeVariants = new string[0]
                                },
                                Backpack = new
                                {
                                    items = new string[1] { Data.Saved.favorite_backpack },
                                    activeVariants = new string[0]
                                },
                                SkyDiveContrail = new
                                {
                                    items = new string[1] { Data.Saved.favorite_skydivecontrail },
                                    activeVariants = new string[0]
                                },
                                Dance = new
                                {
                                    items = Data.Saved.favorite_dance,
                                },
                                LoadingScreen = new
                                {
                                    items = new string[1] { Data.Saved.favorite_loadingscreen },
                                },
                                Pickaxe = new
                                {
                                    items = new string[1] { Data.Saved.favorite_pickaxe },
                                    activeVariants = new string[0]
                                },
                                Glider = new
                                {
                                    items = new string[1] { Data.Saved.favorite_glider },
                                    activeVariants = new string[0]
                                },
                                ItemWrap = new
                                {
                                    items = Data.Saved.favorite_itemwraps,
                                }
                            }
                        },
                        use_count = 1,
                        banner_icon_template = Data.Saved.banner_icon,
                        banner_color_template = Data.Saved.banner_color,
                        locker_name = "clouds",
                        item_seen = false,
                        favorite = false
                    },
                    quantity = 1
                });
                itemsFormatted.Add("loadout_1", new
                {
                    templateId = "CosmeticLocker:cosmeticlocker_athena",
                    attributes = new
                    {
                        locker_slots_data = new
                        {
                            slots = new
                            {
                                MusicPack = new
                                {
                                    items = new string[1] { Data.Saved.favorite_musicpack },
                                },
                                Character = new
                                {
                                    items = Data.Saved.favorite_character,
                                    activeVariants = new string[0]
                                },
                                Backpack = new
                                {
                                    items = Data.Saved.favorite_backpack,
                                    activeVariants = new string[0]
                                },
                                SkyDiveContrail = new
                                {
                                    items = Data.Saved.favorite_skydivecontrail,
                                    activeVariants = new string[0]
                                },
                                Dance = new
                                {
                                    items = Data.Saved.favorite_dance,
                                },
                                LoadingScreen = new
                                {
                                    items = Data.Saved.favorite_loadingscreen,
                                },
                                Pickaxe = new
                                {
                                    items = Data.Saved.favorite_pickaxe,
                                    activeVariants = new string[0]
                                },
                                Glider = new
                                {
                                    items = Data.Saved.favorite_glider,
                                    activeVariants = new string[0]
                                },
                                ItemWrap = new
                                {
                                    items = Data.Saved.favorite_itemwraps,
                                }
                            }
                        },
                        use_count = 0,
                        banner_icon_template = Data.Saved.banner_icon,
                        banner_color_template = Data.Saved.banner_color,
                        locker_name = "clouds",
                        item_seen = false,
                        favorite = false
                    },
                    quantity = 1
                });
                foreach (var item in values)
                {
                    var itemGuid = item.ToString();
                    Console.WriteLine(itemGuid);
                    itemsFormatted.Add(itemGuid, new
                    {
                        templateId = item.ToString(),
                        attributes = new
                        {
                            max_level_bonus = 0,
                            level = 1,
                            item_seen = 1,
                            xp = 0,
                            variants = new List<object>(),
                            favorite = false
                        },
                        quantity = 1
                    });
                }
                return new QueryProfileAthenaModels()
                {
                    profileRevision = Data.Saved.profilerevision,
                    profileChangesBaseRevision = Data.Saved.profilerevision,
                    profileCommandRevision = Data.Saved.profilerevision,
                    profileChanges = new List<profileChanges23>()
                    {
                        new profileChanges23()
                        {
                            changeType = "fullProfileUpdate",
                            _id = "RANDOM",
                            profile = new profileomgss()
                            {
                               _id = "RANDOM",
                               Update = "",
                               Created = "2021-03-07T16:33:28.462Z",
                               updated = "2021 - 05-20T14:57:29.907Z",
                               rvn = 0,
                               wipeNumber = 1,
                               accountId = Data.Saved.AccountId,
                               profileId = profileIdOMG,
                               items = itemsFormatted,
                               stats = new fdsfsdsddffsd()
                               {
                                   attributes = new attributes69()
                                   {

                                   }
                               },
                               version = "no_version"
                            }
                        }
                    }
                };
            }
            else
            {
                profileIdOMG = profileId;
                return new QueryProfileAthenaModels()
                {
                    profileChanges = new List<profileChanges23>()
                    {
                        
                    }
                };
            }
        }

        public static string profileChangesCodeName = "";
        public static string profileChangesCodeValue = "";
        public class profileChangesCode
        {
            public string changeType { get; set; }
            public string name { get; set; }
            public string value { get; set; }
        }

        public class EquipEpics
        {
            public int profileRevision { get; set; } = Data.Saved.profilerevision;
            public string profileId { get; set; } = "athena";
            public int profileChangesBaseRevision { get; set; } = Data.Saved.profilerevision;
            public List<profileChangesCode> profileChanges { get; set; }
            public int profileCommandRevision { get; set; } = Data.Saved.profilerevision;
            public string serverTime { get; set; } = DateTime.Now.ToString("yyyy-MM-ddThh-mm-ssZ");
            public int responseVersion { get; set; } = 2;
        }

        // THIS IS EPPIC
        public class EquipBattleRoyaleCustomizationBody
        {
            public string slotName { get; set; }
            public string itemToSlot { get; set; }
            public int indexWithinSlot { get; set; }
            public string category { get; set; }
        }

        //http://localhost:6980/fortnite/api/game/v2/profile/ABCABC/client/EquipBattleRoyaleCustomization
        [HttpPost("game/v2/profile/{AccountId}/client/EquipBattleRoyaleCustomization")]
        public ActionResult<EquipEpics> EquipBattleRoyaleCustomization([FromQuery] string profileId, [FromBody] EquipBattleRoyaleCustomizationBody body)
        {
            
            try
            {
                if (body.slotName == "ItemWrap" || body.slotName == "Dance")
                {
                    var NumOfItems = body.slotName == "Dance" ? 6 : 7;
                    if (body.indexWithinSlot == -1)
                    {
                        for (var i = 0; i < NumOfItems; i++)
                        {
                            if (body.itemToSlot.Split(":")[0] == "AthenaDance")
                            {
                                Data.Saved.favorite_dance[i] = body.itemToSlot;
                            }
                            else
                            {
                                Data.Saved.favorite_itemwraps[i] = body.itemToSlot;
                            }
                        }
                    }
                    else
                    {
                        if (body.itemToSlot == "")
                        {
                            if (body.slotName.ToLower() == "dance")
                            {
                                Data.Saved.favorite_dance[body.indexWithinSlot] = "";
                            }
                            else
                            {
                                Data.Saved.favorite_itemwraps[body.indexWithinSlot] = "";
                            }
                        }
                        else
                        {
                            if (body.itemToSlot.Split(":")[0] == "AthenaDance")
                            {
                                Console.WriteLine("E", body.indexWithinSlot);
                                Data.Saved.favorite_dance[body.indexWithinSlot] = body.itemToSlot;
                            }
                            else
                            {
                                Data.Saved.favorite_itemwraps[body.indexWithinSlot] = body.itemToSlot;
                            }
                        }
                    }

                }
                else
                { 
                    Console.WriteLine("E", body.itemToSlot);
                    if (body.itemToSlot == "")
                    {
                        Console.WriteLine("TEST");
                        Console.WriteLine(body.slotName);
                        if (body.slotName.ToLower() == "character")
                        {
                            Data.Saved.favorite_character = "";
                        }
                        else if (body.slotName.ToLower() == "backpack")
                        {
                            Data.Saved.favorite_backpack = "";
                        }
                        else if (body.slotName.ToLower() == "pickaxe")
                        {
                            Data.Saved.favorite_pickaxe = "";
                        }
                        else if (body.slotName.ToLower() == "glider")
                        {
                            Data.Saved.favorite_glider = "";
                        }
                        else if (body.slotName.ToLower() == "skydivecontrail")
                        {
                            Data.Saved.favorite_skydivecontrail = "";
                        }
                        else if (body.slotName.ToLower() == "musicpack")
                        {
                            Data.Saved.favorite_musicpack = "";
                        }
                        else if (body.slotName.ToLower() == "loadingscreen")
                        {
                            Data.Saved.favorite_loadingscreen = "";
                        }
                    }
                    else
                    {
                        if(body.itemToSlot.Split(":")[0] == "AthenaCharacter")
                        {
                            Data.Saved.favorite_character = body.itemToSlot;
                        }else if(body.itemToSlot.Split(":")[0] == "AthenaBackpack")
                        {
                            Data.Saved.favorite_backpack = body.itemToSlot;
                        }
                        else if(body.itemToSlot.Split(":")[0] == "AthenaPickaxe")
                        {
                            Data.Saved.favorite_pickaxe = body.itemToSlot;
                        }else if (body.itemToSlot.Split(":")[0] == "AthenaGlider")
                        {
                            Data.Saved.favorite_glider = body.itemToSlot;
                        }
                        else if (body.itemToSlot.Split(":")[0] == "AthenaSkyDiveContrail")
                        {
                            Data.Saved.favorite_skydivecontrail = body.itemToSlot;
                        }
                        else if (body.itemToSlot.Split(":")[0] == "AthenaMusicPack")
                        {
                            Data.Saved.favorite_musicpack = body.itemToSlot;
                        }
                        else if (body.itemToSlot.Split(":")[0] == "AthenaLoadingScreen")
                        {
                            Data.Saved.favorite_loadingscreen = body.itemToSlot;
                        }   
                        Console.WriteLine($"{body.slotName.ToString().ToLower()}`]: `{body.itemToSlot.Split(":")[0]}: {body.itemToSlot.Split(":")[1].ToLower()}");
                    }
                }
                    //await account.updateOne({ id: req.params.accountId }, { [`${category.toString().toLowerCase()}.${req.body.indexWithinSlot}`]: `${ItemToSlot.split(":")[0]}:${ItemToSlot.split(":")[1]}` })

                Data.Saved.profilerevision = +Data.Saved.profilerevision + 1; // add one each time so it updates each time
                Console.WriteLine(Data.Saved.profilerevision);
                Console.WriteLine(Data.Saved.favorite_character);
                Console.WriteLine();
                return new EquipEpics()
                {
                    profileChanges = new List<profileChangesCode>()
                    {
                        new profileChangesCode()
                        {
                             changeType = "statModified",
                             name = $"favorite_{body.slotName.ToString().ToLower()}",
                             value = body.itemToSlot
                        }
                     }
                };
            }
            catch (Exception error)
            {
                return NoContent(); // will fail
            }
          
        }
    }
}
