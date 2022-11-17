using CloudBackend.Models.Profile;
using CloudBackend.Models.Profile.Changes;
using CloudBackend.Models.Profile.Equip;
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

        [HttpPost("game/v2/profile/{AccountId}/client/QueryProfile")]
        [HttpPost("game/v2/profile/{AccountId}/client/SetMtxPlatform")]
        [HttpPost("game/v2/profile/{AccountId}/client/ClientQuestLogin")]
        public ActionResult<QueryProfileModels> QueryProfile([FromQuery] string profileId)
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
                return new QueryProfileModels()
                {
                    profileRevision = Data.Saved.profilerevision,
                    profileChangesBaseRevision = Data.Saved.profilerevision,
                    profileCommandRevision = Data.Saved.profilerevision,
                    profileChanges = new List<profileChanges>()
                    {
                        new profileChanges()
                        {
                            changeType = "fullProfileUpdate",
                            _id = "RANDOM",
                            profile = new Profile()
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
                               stats = new Stats()
                               {
                                   attributes = new Attributes()
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
                return new QueryProfileModels();
            }
        }

        public static string profileChangesCodeName = "";
        public static string profileChangesCodeValue = "";
    


        //http://localhost:6980/fortnite/api/game/v2/profile/ABCABC/client/EquipBattleRoyaleCustomization
        [HttpPost("game/v2/profile/{AccountId}/client/EquipBattleRoyaleCustomization")]
        public ActionResult<EquipChanges> EquipBattleRoyaleCustomization([FromQuery] string profileId, [FromBody] EquipBattleRoyaleCustomizationBody body)
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
                return new EquipChanges()
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
