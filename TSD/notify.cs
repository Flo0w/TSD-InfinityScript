using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;
namespace TSD
{
    public class notify
    {
        private static bool isMenuOpen(Entity ent)
        {
            if(ent.HasField("menuopen") && ent.HasField("menuPos"))
            {
               if (ent.GetField<int>("menuopen") == 1 && ent.GetField<int>("menuPos") == 1)
                   return true;
            }

            return false;
        }
        public static void notifyCmd(Entity entity)
        {

                entity.Call("notifyOnPlayerCommand", "spawnbot", "+frag");
                entity.Call("notifyOnPlayerCommand", "movebot", "+actionslot 5");
                entity.Call("notifyOnPlayerCommand", "ufo", "+actionslot 3");
                entity.Call("notifyOnPlayerCommand", "savelocation", "+melee");
                entity.Call("notifyOnPlayerCommand", "loadlocation", "+reload");
                entity.Call("notifyOnPlayerCommand", "setsp", "+actionslot 4");


               entity.OnNotify("spawnbot", player => { if (isMenuOpen(entity)) menuAction.spawnBot(); TSD.closeMenu(player); });
               entity.OnNotify("ufo", player => { if (isMenuOpen(entity)) menuAction.UFOMode(player); TSD.closeMenu(player); });
               entity.OnNotify("savelocation", player => { if (isMenuOpen(entity)) menuAction.saveLocation(player); TSD.closeMenu(player); });
               entity.OnNotify("loadlocation", player => { if (isMenuOpen(entity)) menuAction.teleportToLocation(player); TSD.closeMenu(player); });
               entity.OnNotify("setsp", player => { if (isMenuOpen(entity)) menuAction.setSpawnPoint(player); TSD.closeMenu(player); });
               entity.OnNotify("reload", player => { menuAction.regenAmmo(player); });
               entity.OnNotify("frag", player => { menuAction.regenEquipment(player); });
               entity.OnNotify("smoke", player => { menuAction.regenSpecial(player); });
        }
    }
}
