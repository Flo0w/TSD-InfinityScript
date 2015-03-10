using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;
namespace TSD
{
    class menuAction
    {
        public static string mapName = "";

        public static void onSelect(Entity player)
        {
            if (player.GetField<int>("menuopen") == 1)
            {
                int curPos = player.GetField<int>("curpos");
                switch (player.GetField<int>("menuPos"))
                {
                    case 1:
                        if (curPos == 1)
                            spawnBot();
                        else if (curPos == 2)
                            UFOMode(player);
                        else if (curPos == 3)
                            UFOMode(player);
                        else if (curPos == 4)
                            saveLocation(player);
                        else if (curPos == 5)
                            teleportToLocation(player);
                        else if (curPos == 6)
                            setSpawnPoint(player);
                        break;
                    case 2:
                        if (curPos == 1)
                            player.GiveWeapon("frag_grenade_mp");
                        else if (curPos == 2)
                            player.GiveWeapon("semtex_mp");
                        else if (curPos == 3)
                            player.GiveWeapon("throwingknife_mp");
                        else if (curPos == 4)
                            player.GiveWeapon("bouncingbetty_mp");
                        else if (curPos == 5)
                            player.GiveWeapon("claymore_mp");
                        else if (curPos == 6)
                            player.GiveWeapon("c4_mp");
                        break;
                    case 3:
                        player.TakeWeapon(player.CurrentWeapon);
                        string weapon = "";
                        if (curPos == 1)
                            weapon = "iw5_barrett_mp_barrettscope";
                        else if (curPos == 2)
                            weapon = "iw5_l96a1_mp_l96a1scope";
                        else if (curPos == 3)
                            weapon = "iw5_dragunov_mp_dragunovscope";
                        else if (curPos == 4)
                            weapon = "iw5_as50_mp_as50scope";
                        else if (curPos == 5)
                            weapon = "iw5_rsass_mp_rsassscope";
                        else if (curPos == 6)
                            weapon = "iw5_msr_mp_msrscope";

                        player.GiveWeapon(weapon);
                        player.SwitchToWeaponImmediate(weapon);
                        break;
                    case 4:
                        if (curPos == 1)
                            player.Call("setweaponammostock", player.CurrentWeapon, 0);
                        else if (curPos == 2)
                            player.Call("setweaponammoclip", player.CurrentWeapon, 0);
                        else if (curPos == 3)
                            player.Call("givemaxammo", player.CurrentWeapon);
                        else if (curPos == 4)
                        {
                            if (player.GetField<int>("reg_ammo") == 0)
                                player.SetField("reg_ammo", 1);
                            else
                                player.SetField("reg_ammo", 0);
                        }
                        else if (curPos == 5)
                        {
                            if (player.GetField<int>("reg_special") == 0)
                                player.SetField("reg_special", 1);
                            else
                                player.SetField("reg_special", 0);
                        }
                        else if (curPos == 6)
                        {
                            if (player.GetField<int>("reg_equip") == 0)
                                player.SetField("reg_equip", 1);
                            else
                                player.SetField("reg_equip", 0);
                        }
                        else if (curPos == 7)
                        {
                            if (player.GetField<int>("custom_sp") == 0)
                                player.SetField("custom_sp", 1);
                            else
                                player.SetField("custom_sp", 0);
                        }
                            break;
                    case 5:
                            if (curPos == 1)
                            {
                                if (player.GetField<int>("eb") == 0)
                                    player.SetField("eb", 1);
                                else
                                    player.SetField("eb", 0);

                               explosiveBullets(player);
                            }
                        break;
                    case 6:
                        onMapSelect(player);
                        break;
                    case 7:
                        if (curPos == 1) {
                            if (HudElems.doMove == 0)
                                player.Notify("testClients_doMove#1");
                            else
                                player.Notify("testClients_doMove#0");
                        }
                        else if (curPos == 2) {
                            if (HudElems.doAttack == 0)
                                player.Notify("testClients_doAttack#1");
                            else
                                player.Notify("testClients_doAttack#0");
                        }
                        else if (curPos == 3)
                        {
                            if (HudElems.doReload == 0)
                                player.Notify("testClients_doReload#1");
                            else
                                player.Notify("testClients_doReload#0");
                        }
                        else if (curPos == 4)
                        {
                            if (player.HasField("bots_l"))
                            {
                                if (player.GetField<int>("bots_l") == 0)
                                    player.SetField("bots_l", 1);
                                else
                                    player.SetField("bots_l", 0);
                            }
                        }

                        break;
                }

                TSD.closeMenu(player);
            }
        }

        private static void onMapSelect(Entity player)
        {
            int curPos = player.GetField<int>("curpos");
            if(player.GetField<int>("menuPage") == 1)
            {
                switch(curPos)
                {
                    case 1:
                        mapName = "mp_plaza2";
                        break;
                    case 2:
                        mapName = "mp_mogadishu";
                        break;
                    case 3:
                        mapName = "mp_bootleg";
                        break;
                    case 4:
                        mapName = "mp_carbon";
                        break;
                    case 5:
                        mapName = "mp_dome";
                        break;
                    case 6:
                        mapName = "mp_exchange";
                        break;
                    case 7:
                        mapName = "mp_lambeth";
                        break;
                    case 8:
                        mapName = "mp_hardhat";
                        break;
                    case 9:
                        mapName = "mp_interchange";
                        break;
                    case 10:
                        mapName = "mp_alpha";
                        break;
                    case 11:
                        break;
                }
            }
            else if(player.GetField<int>("menuPage") == 2)
            {
                switch (curPos)
                {
                    case 1:
                        mapName = "mp_bravo";
                        break;
                    case 2:
                        mapName = "mp_radar";
                        break;
                    case 3:
                        mapName = "mp_paris";
                        break;
                    case 4:
                        mapName = "mp_seatown";
                        break;
                    case 5:
                        mapName = "mp_terminal_cls";
                        break;
                    case 6:
                        mapName = "mp_underground";
                        break;
                    case 7:
                        mapName = "mp_village";
                        break;
                    case 8:
                        break;
                }
            }

            player.Notify("changemap");
        }
        public static void spawnBot()
        {
            var testClient = Utilities.AddTestClient();

            if (testClient == null)
                return;

            testClient.OnNotify("joined_spectators", tc =>
            {
                tc.Notify("menuresponse", "team_marinesopfor", "autoassign");
                tc.AfterDelay(500, meh =>
                {
                    meh.Notify("menuresponse", "changeclass", "class1");
                });
            });
        }

        public static void saveLocation(Entity player)
        {
            player.SetField("custom_lo", 1);
            player.SetField("location", player.Origin);
        }

        public static void teleportToLocation(Entity player)
        {
            if (player.HasField("custom_lo") && player.HasField("location"))
            {
                if (player.GetField<int>("custom_lo") == 1)
                {
                    Vector3 origin = player.GetField<Vector3>("location");
                    player.Call("setorigin", origin);
                }
            }
        }

        public static void setSpawnPoint(Entity player)
        {
            player.SetField("custom_sp", 1);
            player.SetField("spawnpoint", player.Origin);
        }

        public static void UFOMode(Entity player)
        {
            if (player.GetField<string>("sessionstate") == "playing")
            {
                player.Call("allowspectateteam", "freelook", true);
                player.SetField("sessionstate", "spectator");
            }
            else
            {
                player.Call("allowspectateteam", "freelook", false);
                player.SetField("sessionstate", "playing");
            }
        }
        public static void explosiveBullets(Entity player)
        {
            if (player.HasField("eb"))
            {
                if (player.GetField<int>("eb") == 1)
                {
                    player.Call("setperk", "specialty_explosivebullets", 1, 0);
                    player.SetClientDvar("bg_bulletExplDmgFactor", "10");
                    player.SetClientDvar("bg_bulletExplRadius", "999");
                }
                else if (player.GetField<int>("eb") == 0)
                {
                    player.Call("setperk", "specialty_explosivebullets", 0, 0);
                    player.SetClientDvar("bg_bulletExplDmgFactor", "1");
                    player.SetClientDvar("bg_bulletExplRadius", "250");
                }
            }
        }

        public static void regenAmmo(Entity player)
        {
            if (player.HasField("reg_ammo"))
            {
                if (player.GetField<int>("reg_ammo") == 1)
                {
                    player.Call("givemaxammo", player.CurrentWeapon);
                }
            }
        }

        public static void regenSpecial(Entity player)
        {
            var currentOffHand = player.Call<string>("getcurrentoffhand");

            if (player.HasField("reg_special"))
            {
                if (player.GetField<int>("reg_special") == 1)
                {
                    player.Call("givemaxammo", currentOffHand);
                    player.Call("setweaponammoclip", currentOffHand, 9999);
                }
            }
        }

        public static void regenEquipment(Entity player)
        {
            var currentOffHand = player.Call<string>("getcurrentoffhand");

            if (player.HasField("reg_equip"))
            {
                if (player.GetField<int>("reg_equip") == 1)
                {
                    player.Call("givemaxammo", currentOffHand);
                    player.Call("setweaponammoclip", currentOffHand, 9999);
                }
            }
        }

        public static void moveBots(Entity player, List<Entity>Players)
        {
            foreach (var iplayer in Players)
            {
                if (iplayer.Name.StartsWith("bot"))
                {
                    var origin = player.Call<Vector3>("getorigin");
                    iplayer.Call("setorigin", origin);
                }
            }
        }

        /*public static void slowMotion(Entity player)
        {
            if (player.HasField("sm"))
            {
                if (player.GetField<int>("sm") == 0)
                    player.Notify("timescale#0.75");
                else if (player.GetField<int>("sm") == 1)
                    player.Notify("timescale#0.5");
                else if (player.GetField<int>("sm") == 2)
                    player.Notify("timescale#0.25");
                else if (player.GetField<int>("sm") == 3)
                    player.Notify("timescale#1");
            }
        }*/
    }
}
