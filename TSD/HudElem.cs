using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;
namespace TSD
{
    class HudElems : BaseScript
    {
        private static HudElem Menu1;
        private static HudElem SubMenu1, SubMenu2;
        private static HudElem Text1, Text2, Text3, Text4, Text5, Text6, Text7, Text8, Text9, Text10, Text11;
        public static int doMove, doAttack, doReload;
        public static void setupHudElems(Entity player)
        {
            Menu1 = HudElem.CreateFontString(player, "default", 2.0f);
            Menu1.SetPoint("CENTER", "CENTER", 0, -150);
            SubMenu1 = HudElem.CreateFontString(player, "default", 1.5f);
            SubMenu1.SetPoint("CENTER", "CENTER", -200, -150);
            SubMenu2 = HudElem.CreateFontString(player, "default", 1.5f);
            SubMenu2.SetPoint("CENTER", "CENTER", 200, -150);
            Text1 = HudElem.CreateFontString(player, "default", 1.5f);
            Text1.SetPoint("CENTER", "CENTER", 0, -80);
            Text2 = HudElem.CreateFontString(player, "default", 1.5f);
            Text2.SetPoint("CENTER", "CENTER", 0, -60);
            Text3 = HudElem.CreateFontString(player, "default", 1.5f);
            Text3.SetPoint("CENTER", "CENTER", 0, -40);
            Text4 = HudElem.CreateFontString(player, "default", 1.5f);
            Text4.SetPoint("CENTER", "CENTER", 0, -20);
            Text5 = HudElem.CreateFontString(player, "default", 1.5f);
            Text5.SetPoint("CENTER", "CENTER", 0, 0);
            Text6 = HudElem.CreateFontString(player, "default", 1.5f);
            Text6.SetPoint("CENTER", "CENTER", 0, 20);
            Text7 = HudElem.CreateFontString(player, "default", 1.5f);
            Text7.SetPoint("CENTER", "CENTER", 0, 40);
            Text8 = HudElem.CreateFontString(player, "default", 1.5f);
            Text8.SetPoint("CENTER", "CENTER", 0, 60);
            Text9 = HudElem.CreateFontString(player, "default", 1.5f);
            Text9.SetPoint("CENTER", "CENTER", 0, 80);
            Text10 = HudElem.CreateFontString(player, "default", 1.5f);
            Text10.SetPoint("CENTER", "CENTER", 0, 100);
            Text11 = HudElem.CreateFontString(player, "default", 1.5f);
            Text11.SetPoint("CENTER", "CENTER", 0, 120);
        }
        public static void DestroyHudElems(Entity player)
        {
            player.Call("freezecontrols", false);
            Menu1.SetText("");
            SubMenu1.SetText("");
            SubMenu2.SetText("");
            cleanText();
        }
        
        private static void cleanText()
        {
            Text1.SetText("");
            Text2.SetText("");
            Text3.SetText("");
            Text4.SetText("");
            Text5.SetText("");
            Text6.SetText("");
            Text7.SetText("");
            Text8.SetText("");
            Text9.SetText("");
            Text10.SetText("");
            Text11.SetText("");
        }
        public static void switchPage(Entity player, int move, int attack, int reload)
        {
            doMove = move;
            doAttack = attack;
            doReload = reload;

            player.SetField("curpos", 1);
            createMenu(player);
            createSubMenu(player);
            createText(player);
        }
        public static void createMenu(Entity player)
        {
                if(player.GetField<int>("menuopen") == 1)
                {
                    switch(player.GetField<int>("menuPos"))
                    {
                        case 1:
                            Menu1.SetText("^6Teleport Menu");
                            break;
                        case 2:
                            Menu1.SetText("^6Equipment Menu");
                            break;
                        case 3:
                            Menu1.SetText("^6Sniper Menu");
                            break;
                        case 4:
                            Menu1.SetText("^6Character Preferences");
                            break;
                        case 5:
                            Menu1.SetText("^6Match Settings");
                            break;
                        case 6:
                            Menu1.SetText("^6Change Map");
                            break;
                        case 7:
                            Menu1.SetText("^6Bot Settings");
                            break;
                    }
                }
        }

        public static void createSubMenu(Entity player)
        {
            player.SetField("admin", 0);

                if (player.GetField<int>("menuopen") == 1)
                {
                    if (player.GetField<int>("menuPos") == 1)
                    {
                        if (player.GetField<int>("admin") == 1)
                            SubMenu1.SetText("^3Kick Players");
                        else
                            SubMenu1.SetText("^3Bot settings");

                        SubMenu2.SetText("^3Equipment");
                    }
                    else if (player.GetField<int>("menuPos") == 2)
                    {
                        SubMenu1.SetText("^3Teleports");
                        SubMenu2.SetText("^3Snipers");
                    }
                    else if (player.GetField<int>("menuPos") == 3)
                    {
                        SubMenu1.SetText("^3Equipments");
                        SubMenu2.SetText("^3Characters");
                    }
                    else if (player.GetField<int>("menuPos") == 4)
                    {
                        SubMenu1.SetText("^3Snipers");
                        SubMenu2.SetText("^3Settings");
                    }
                    else if (player.GetField<int>("menuPos") == 5)
                    {
                        SubMenu1.SetText("^3Characters");
                        SubMenu2.SetText("^3Change map");
                    }
                    else if (player.GetField<int>("menuPos") == 6)
                    {
                        SubMenu1.SetText("^3Settings");
                        SubMenu2.SetText("^3Bots Settings");
                    }
                    else if (player.GetField<int>("menuPos") == 7)
                    {
                        SubMenu1.SetText("^3Change map");
                        SubMenu2.SetText("^3Teleports");
                    }
            }
        }

        public static void createText(Entity player)
        {
            int curPos = player.GetField<int>("curpos");
            if(player.GetField<int>("menuopen") == 1)
            {
                switch(player.GetField<int>("menuPos"))
                {
                    case 1:
                        cleanText();
                       if (curPos == 1)
                            Text1.SetText("^2Press ^3[{+frag}] ^2to ^3spawn 1 bot");
                        else if (curPos != 1)
                            Text1.SetText("^1Press ^3[{+frag}] ^1to ^3spawn 1 bot");
                        if (curPos == 2)
                            Text2.SetText("^2Enter ^3UFO ^2mode and ^3press [{+actionslot 5}] to move the bots");
                        else if (curPos != 2)
                            Text2.SetText("^1Enter ^3UFO ^1mode and ^3press [{+actionslot 5}] to move the bots");
                        if (curPos == 3)
                            Text3.SetText("^2Press ^3[{+actionslot 3}] ^2to ^3enter or exit UFO mode");
                        else if (curPos != 3)
                            Text3.SetText("^1Press ^3[{+actionslot 3}] ^1to ^3enter or exit UFO mode");
                        if (curPos == 4)
                            Text4.SetText("^2Press ^3[{+melee}]^2 to save your location");
                        else if (curPos != 4)
                            Text4.SetText("^1Press ^3[{+melee}]^1 to save your location");
                        if (curPos == 5)
                            Text5.SetText("^2Press ^3[{+reload}] ^2to load your saved location");
                        else if (curPos != 5)
                            Text5.SetText("^1Press ^3[{+reload}] ^1to load your saved location");
                        if (curPos == 6)
                            Text6.SetText("^2Press ^3[{+actionslot 4}] ^2to set your spawn point.");
                        else if (curPos != 6)
                            Text6.SetText("^1Press ^3[{+actionslot 4}] ^1to set your spawn point.");
                        break;
                    case 2:
                        cleanText();
                        if (curPos == 1)
                            Text1.SetText("^2Frag grenade");
                        else if (curPos != 1)
                            Text1.SetText("^1Frag grenade");
                        if (curPos == 2)
                            Text2.SetText("^2Semtex");
                        else if (curPos != 2)
                            Text2.SetText("^1Semtex");
                        if (curPos == 3)
                            Text3.SetText("^2Throwing knife");
                        else if (curPos != 3)
                            Text3.SetText("^1Throwing knife");
                        if (curPos == 4)
                            Text4.SetText("^2Boucing betty");
                        else if (curPos != 4)
                            Text4.SetText("^1Boucing betty");
                        if (curPos == 5)
                            Text5.SetText("^2Claymore");
                        else if (curPos != 5)
                            Text5.SetText("^1Claymore");
                        if (curPos == 6)
                            Text6.SetText("^2C4");
                        else if (curPos != 6)
                            Text6.SetText("^1C4");
                        break;
                    case 3:
                        cleanText();
                        if (curPos == 1)
                            Text1.SetText("^2Barrett .50cal");
                        else if (curPos != 1)
                            Text1.SetText("^1Barrett .50cal");
                        if (curPos == 2)
                            Text2.SetText("^2L118A");
                        else if (curPos != 2)
                            Text2.SetText("^1L118A");
                        if (curPos == 3)
                            Text3.SetText("^2Dragunov");
                        else if (curPos != 3)
                            Text3.SetText("^1Dragunov");
                        if (curPos == 4)
                            Text4.SetText("^2AS50");
                        else if (curPos != 4)
                            Text4.SetText("^1AS50");
                        if (curPos == 5)
                            Text5.SetText("^2RSASS");
                        else if (curPos != 5)
                            Text5.SetText("^1RSASS");
                        if (curPos == 6)
                            Text6.SetText("^2MSR");
                        else if (curPos != 6)
                            Text6.SetText("^1MSR");
                        break;
                    case 4:
                        cleanText();
                        if (curPos == 1)
                            Text1.SetText("^2Set Ammo In Stock To 0");
                        else if (curPos != 1)
                            Text1.SetText("^1Set Ammo In Stock To 0");
                        if (curPos == 2)
                            Text2.SetText("^2Set Ammo In Clip To 0");
                        else if (curPos != 2)
                            Text2.SetText("^1Set Ammo In Clip To 0");
                        if (curPos == 3)
                            Text3.SetText("^2Refill Everything");
                        else if (curPos != 3)
                            Text3.SetText("^1Refill Everything");
                        if (curPos == 4)
                            Text4.SetText("^2Regen. Ammo On Reload: ^3" + player.GetField<int>("reg_ammo").ToString());
                        else if (curPos != 4)
                            Text4.SetText("^1Regen. Ammo On Reload: ^3" + player.GetField<int>("reg_ammo").ToString());
                        if (curPos == 5)
                            Text5.SetText("^2Regen. Special Grenades On Use: ^3" + player.GetField<int>("reg_special").ToString());
                        else if (curPos != 5)
                            Text5.SetText("^1Regen. Special Grenades On Use: ^3" + player.GetField<int>("reg_special").ToString());
                        if (curPos == 6)
                            Text6.SetText("^2Regen. Equipment On Use: ^3" + player.GetField<int>("reg_equip").ToString());
                        else if (curPos != 6)
                            Text6.SetText("^1Regen. Equipment On Use: ^3" + player.GetField<int>("reg_equip").ToString());
                        if (curPos == 7)
                            Text7.SetText("^2Use Custom Spawn Point: ^3" + player.GetField<int>("custom_sp").ToString());
                        else if (curPos != 7)
                            Text7.SetText("^1Use Custom Spawn Point: ^3" + player.GetField<int>("custom_sp").ToString());
                        break;
                    case 5:
                        cleanText();
                        if (curPos == 1)
                            Text1.SetText("^2Explosive bullets: ^3" + player.GetField<int>("eb").ToString());
                        else if (curPos != 1)
                            Text1.SetText("^1Explosive bullets: ^3" + player.GetField<int>("eb").ToString());
                        /*if (curPos == 2)
                            Text2.SetText("^2Slow motion: ^3" + player.GetField<int>("sm").ToString());
                        else if (curPos != 2)
                            Text2.SetText("^1Slow motion: ^3" + player.GetField<int>("sm").ToString());*/
                        break;
                    case 6:
                        if (player.GetField<int>("menuPage") == 1)
                        {
                            cleanText();

                            if (curPos == 1)
                                Text1.SetText("^2Arkaden");
                            else if (curPos != 1)
                                Text1.SetText("^1Arkaden");
                            if (curPos == 2)
                                Text2.SetText("^2Bakaara");
                            else if (curPos != 2)
                                Text2.SetText("^1Bakaara");
                            if (curPos == 3)
                                Text3.SetText("^2Bootleg");
                            else if (curPos != 3)
                                Text3.SetText("^1Bootleg");
                            if (curPos == 4)
                                Text4.SetText("^2Carbon");
                            else if (curPos != 4)
                                Text4.SetText("^1Carbon");
                            if (curPos == 5)
                                Text5.SetText("^2Dome");
                            else if (curPos != 5)
                                Text5.SetText("^1Dome");
                            if (curPos == 6)
                                Text6.SetText("^2Downturn");
                            else if (curPos != 6)
                                Text6.SetText("^1Downturn");
                            if (curPos == 7)
                                Text7.SetText("^2Fallen");
                            else if (curPos != 7)
                                Text7.SetText("^1Fallen");
                            if (curPos == 8)
                                Text8.SetText("^2Hardhat");
                            else if (curPos != 8)
                                Text8.SetText("^1Hardhat");
                            if (curPos == 9)
                                Text9.SetText("^2Interchange");
                            else if (curPos != 9)
                                Text9.SetText("^1Interchange");
                            if (curPos == 10)
                                Text10.SetText("^2Lockdown");
                            else if (curPos != 10)
                                Text10.SetText("^1Lockdown");
                            if (curPos == 11)
                                Text11.SetText("^2Next page");
                            else if (curPos != 11)
                                Text11.SetText("^1Next page");
                        }
                        else if (player.GetField<int>("menuPage") == 2)
                        {
                            cleanText();

                            if (curPos == 1)
                                Text1.SetText("^2Mission");
                            else if (curPos != 1)
                                Text1.SetText("^1Mission");
                            if (curPos == 2)
                                Text2.SetText("^2Outpost");
                            else if (curPos != 2)
                                Text2.SetText("^1Outpost");
                            if (curPos == 3)
                                Text3.SetText("^2Resistance");
                            else if (curPos != 3)
                                Text3.SetText("^1Resistance");
                            if (curPos == 4)
                                Text4.SetText("^2Seatown");
                            else if (curPos != 4)
                                Text4.SetText("^1Seatown");
                            if (curPos == 5)
                                Text5.SetText("^2Terminal");
                            else if (curPos != 5)
                                Text5.SetText("^1Terminal");
                            if (curPos == 6)
                                Text6.SetText("^2Underground");
                            else if (curPos != 6)
                                Text6.SetText("^1Underground");
                            if (curPos == 7)
                                Text7.SetText("^2Village");
                            else if (curPos != 7)
                                Text7.SetText("^1Village");
                            if (curPos == 8)
                                Text8.SetText("^2Previous page");
                            else if (curPos != 8)
                                Text8.SetText("^1Previous page");
                        }
                        break;
                    case 7:
                        cleanText();

                        if (curPos == 1)
                            Text1.SetText("^2Bots Move: ^3" + doMove.ToString());
                        else if (curPos != 1)
                            Text1.SetText("^1Bots Move: ^3" + doMove.ToString());
                        if (curPos == 2)
                            Text2.SetText("^2Bots Shoot: ^3" + doAttack.ToString());
                        else if (curPos != 2)
                            Text2.SetText("^1Bots Shoot: ^3" + doAttack.ToString());
                        if (curPos == 3)
                            Text3.SetText("^2Bots Reload: ^3" + doReload.ToString());
                        else if (curPos != 3)
                            Text3.SetText("^1Bots Reload: ^3" + doReload.ToString());
                        if (curPos == 4)
                            Text4.SetText("^2Bots Lock On: ^3" + player.GetField<int>("bots_lo").ToString());
                        else if (curPos != 4)
                            Text4.SetText("^1Bots Lock On: ^3" + player.GetField<int>("bots_lo").ToString());
                        break;
                }
            }
        }
    }
}
