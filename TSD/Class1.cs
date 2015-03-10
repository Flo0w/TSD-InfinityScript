using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;

namespace TSD
{
    public class TSD : BaseScript
    {
        public TSD()
        {
            setupBotDvars();

            PlayerConnected += new Action<Entity>(entity =>
            {
                if (!entity.Name.StartsWith("bot"))
                {
                    setupVariables(entity);
                    HudElems.setupHudElems(entity);
                }

                notify.notifyCmd(entity);

                entity.Call("notifyOnPlayerCommand", "openmenu", "+actionslot 4");

                entity.OnNotify("openmenu", player =>
                {
                    if(player.HasField("menuopen") && !player.Name.StartsWith("bot"))
                    {
                        if (player.GetField<int>("menuopen") == 0)
                        {
                            player.Call("freezecontrols", true);
                            player.Call("setblurforplayer", 4, 0.2f);
                            player.SetField("menuPage", 1);
                            player.SetField("menuopen", 1);
                            player.SetField("menuPos", 1);
                            HudElems.switchPage(player, Call<int>("getdvarint", "testClients_doMove"), Call<int>("getdvarint", "testClients_doAttack"), Call<int>("getdvarint", "testClients_doReload"));
                        }
                        else
                            closeMenu(player);
                    }
                    else
                    {
                        player.Call("freezecontrols", true);
                        player.Call("setblurforplayer", 4, 0.2f);
                        player.SetField("menuopen", 1);
                        player.SetField("menuPage", 1);
                        player.SetField("menuPos", 1);
                        HudElems.switchPage(player, Call<int>("getdvarint", "testClients_doMove"), Call<int>("getdvarint", "testClients_doAttack"), Call<int>("getdvarint", "testClients_doReload"));
                    }
                });

                entity.Call("notifyOnPlayerCommand", "switchpage+", "+moveright");
                entity.OnNotify("switchpage+", player =>
                {
                    if (player.HasField("menuopen"))
                    {
                        if (player.HasField("menuPos"))
                        {
                            if (player.GetField<int>("menuopen") == 1)
                            {
                                int menuPos = player.GetField<int>("menuPos");
                                if (menuPos >= 1 && menuPos != 7)
                                    player.SetField("menuPos", menuPos += 1);
                                else if (menuPos == 7)
                                    player.SetField("menuPos", 1);

                                HudElems.switchPage(player, Call<int>("getdvarint", "testClients_doMove"), Call<int>("getdvarint", "testClients_doAttack"), Call<int>("getdvarint", "testClients_doReload"));
                            }
                        }
                    }
                });

                entity.Call("notifyOnPlayerCommand", "switchpage-", "+moveleft");
                entity.OnNotify("switchpage-", player =>
                {
                    if (player.HasField("menuopen"))
                    {
                        if (player.HasField("menuPos"))
                        {
                            if (player.GetField<int>("menuopen") == 1)
                            {
                                int menuPos = player.GetField<int>("menuPos");

                                if (menuPos <= 7 && menuPos != 1)
                                    player.SetField("menuPos", menuPos -= 1);
                                else if (menuPos == 1)
                                    player.SetField("menuPos", 7);

                                HudElems.switchPage(player, Call<int>("getdvarint", "testClients_doMove"), Call<int>("getdvarint", "testClients_doAttack"), Call<int>("getdvarint", "testClients_doReload"));
                            }
                        }
                    }
                });

                entity.Call("notifyOnPlayerCommand", "uppos", "+forward");
                entity.OnNotify("uppos", player =>
                {
                    if (player.HasField("menuopen"))
                    {
                        if (player.HasField("menuPos"))
                        {
                            if (player.GetField<int>("menuopen") == 1)
                            {
                                int menuPos = player.GetField<int>("menuPos");
                                int menuPage = player.GetField<int>("menuPage");
                                int curPos = player.GetField<int>("curpos");

                                switch(menuPos)
                                {
                                    case 1:
                                        if(curPos <= 6 && curPos != 1)
                                            player.SetField("curpos", curPos -= 1);
                                        else if(curPos == 1)
                                            player.SetField("curpos", 6);
                                        break;
                                    case 2:
                                        if (curPos <= 6 && curPos != 1)
                                            player.SetField("curpos", curPos -= 1);
                                        else if (curPos == 1)
                                            player.SetField("curpos", 6);
                                        break;
                                    case 3:
                                        if (curPos <= 5 && curPos != 1)
                                            player.SetField("curpos", curPos -= 1);
                                        else if (curPos == 1)
                                            player.SetField("curpos", 6);
                                        break;
                                    case 4:
                                        if (curPos <= 7 && curPos != 1)
                                            player.SetField("curpos", curPos -= 1);
                                        else if (curPos == 1)
                                            player.SetField("curpos", 7);
                                        break;
                                    case 5:
                                            player.SetField("curpos", 1);
                                        break;
                                    case 6:
                                        if (menuPage == 1)
                                        {
                                            if (curPos <= 11 && curPos != 1)
                                                player.SetField("curpos", curPos -= 1);
                                            else if (curPos == 1)
                                                player.SetField("curpos", 11);
                                        }
                                        else if (menuPage == 2)
                                        {
                                            if (curPos <= 8 && curPos != 1)
                                                player.SetField("curpos", curPos -= 1);
                                            else if (curPos == 1)
                                                player.SetField("curpos", 8);
                                        }
                                        break;
                                    case 7:
                                        if (curPos <= 4 && curPos != 1)
                                            player.SetField("curpos", curPos -= 1);
                                        else if (curPos == 1)
                                            player.SetField("curpos", 4);
                                        break;
                                }
                                HudElems.createText(player);
                            }
                        }
                    }
                });
                entity.Call("notifyOnPlayerCommand", "downpos", "+back");
                entity.OnNotify("downpos", player =>
                {
                    if (player.HasField("menuopen"))
                    {
                        if (player.HasField("menuPos"))
                        {
                            if (player.GetField<int>("menuopen") == 1)
                            {
                                int menuPos = player.GetField<int>("menuPos");
                                int menuPage = player.GetField<int>("menuPage");
                                int curPos = player.GetField<int>("curpos");

                                switch (menuPos)
                                {
                                    case 1:
                                        if (curPos >= 1 && curPos != 6)
                                            player.SetField("curpos", curPos += 1);
                                        else if (curPos == 6)
                                            player.SetField("curpos", 1);
                                        break;
                                    case 2:
                                        if (curPos >= 1 && curPos != 6)
                                            player.SetField("curpos", curPos += 1);
                                        else if (curPos == 6)
                                            player.SetField("curpos", 1);
                                        break;
                                    case 3:
                                        if (curPos >= 1 && curPos != 6)
                                            player.SetField("curpos", curPos += 1);
                                        else if (curPos == 6)
                                            player.SetField("curpos", 1);
                                        break;
                                    case 4:
                                        if (curPos >= 1 && curPos != 7)
                                            player.SetField("curpos", curPos += 1);
                                        else if (curPos == 7)
                                            player.SetField("curpos", 1);
                                        break;
                                    case 5:
                                            player.SetField("curpos", 1);
                                        break;
                                    case 6:
                                        if (menuPage == 1)
                                        {
                                            if (curPos >= 1 && curPos != 11)
                                                player.SetField("curpos", curPos += 1);
                                            else if (curPos == 11)
                                                player.SetField("curpos", 1);
                                        }
                                        else if (menuPage == 2)
                                        {
                                            if (curPos >= 1 && curPos != 8)
                                                player.SetField("curpos", curPos += 1);
                                            else if (curPos == 8)
                                                player.SetField("curpos", 1);
                                        }
                                        break;
                                    case 7:
                                        if (curPos >= 1 && curPos != 4)
                                            player.SetField("curpos", curPos += 1);
                                        else if (curPos == 4)
                                            player.SetField("curpos", 1);
                                        break;
                                }
                                HudElems.createText(player);
                            }
                        }
                    }
                });

                entity.Call("notifyOnPlayerCommand", "select", "+gostand");
                entity.OnNotify("select", player =>
                {
                    if (player.HasField("menuopen"))
                    {
                        if (player.GetField<int>("menuopen") == 1)
                            menuAction.onSelect(player);
                    }
                });

            });

            PlayerConnected += new Action<Entity>(entity =>
            {
                entity.OnNotify("testClients_doMove#0", player => Call("setdvar", "testClients_doMove", "0"));
                entity.OnNotify("testClients_doMove#1", player => Call("setdvar", "testClients_doMove", "1"));
                entity.OnNotify("testClients_doAttack#0", player => Call("setdvar", "testClients_doAttack", "0"));
                entity.OnNotify("testClients_doAttack#1", player => Call("setdvar", "testClients_doAttack", "1"));
                entity.OnNotify("testClients_doReload#0", player => Call("setdvar", "testClients_doReload", "0"));
                entity.OnNotify("testClients_doReload#1", player => Call("setdvar", "testClients_doReload", "1"));

                entity.OnNotify("timescale#1", player => Call("setdvar", "timescale", "1"));
                entity.OnNotify("timescale#0.75", player => Call("setdvar", "timescale", "0.75"));
                entity.OnNotify("timescale#0.5", player => Call("setdvar", "timescale", "0.5"));
                entity.OnNotify("timescale#0.25", player => Call("setdvar", "timescale", "0.25"));
                entity.OnNotify("movebot", player => { if (player.GetField<string>("sessionstate") == "spectator") menuAction.moveBots(player,Players); TSD.closeMenu(player); });
                
                entity.OnNotify("changemap", map => { Call("map", menuAction.mapName); });
                
                entity.OnNotify("death", player => { if (player.Name.StartsWith("bot")) player.SetField("last_origin_bd", player.Origin); });
                entity.SpawnedPlayer += new Action(() =>
                {
                    if(entity.Name.StartsWith("bot") && entity.HasField("last_origin_bd"))
                    {
                        Vector3 last_origin = entity.GetField<Vector3>("last_origin_bd");
                        entity.Call("setorigin", last_origin);
                    }
                });

                entity.SpawnedPlayer += new Action(() =>
                {
                    if(entity.HasField("eb"))
                    {
                        if (entity.GetField<int>("eb") == 1)
                            menuAction.explosiveBullets(entity);
                    }
                    if(entity.HasField("custom_sp") && entity.HasField("spawnpoint"))
                    {
                        if (entity.GetField<int>("custom_sp") == 1)
                        {
                            Vector3 spawnpoint = entity.GetField<Vector3>("spawnpoint");
                            entity.Call("setorigin", spawnpoint);
                        }
                    }
                });
            });
        }
        public static void closeMenu(Entity player)
        {
            if (player.HasField("menuopen"))
            {
                if (player.GetField<int>("menuopen") == 1)
                {
                    player.SetField("menuopen", 0);
                    player.SetField("menuPos", 0);
                    HudElems.DestroyHudElems(player);
                    player.Call("setblurforplayer", 0, 0.2f);
                }
            }
        }

        private void setupBotDvars()
        {
            Call("setdvar", "testClients_doMove", 0);
            Call("setdvar", "testClients_doAttack", 0);
            Call("setdvar", "testClients_doReload", 0);
        }
        private void setupVariables(Entity player)
        {
            player.SetField("reg_ammo", 0);
            player.SetField("reg_special", 0);
            player.SetField("reg_equip", 0);
            player.SetField("custom_sp", 0);
            player.SetField("custom_lo", 0);
            player.SetField("eb", 0);
            player.SetField("sm", 0);
            player.SetField("bots_m", 0);
            player.SetField("bots_s", 0);
            player.SetField("bots_r", 0);
            player.SetField("bots_lo", 0);
        }


        public override void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc)
        {
            if (mod == "MOD_FALLING")
                player.Health += damage; // add to victim's health suffered damage - this way we disable fall damage

        }
    }
}
