//Not implemented yet

using _app.Scripts.Managers;
using UnityEngine;
namespace _app.Scripts.Systems
{
    public class Upgrade : MonoBehaviour
    {
        //upgrade type
        public int upgradeType; //1 for backpack, 2 for boots
        
        //upgrade number
        //keeps track of how many upgrades have been given already 
        public int backpackUpgrades;
        public int bootsUpgrades;

        private int getUpgradeRequirement()
        {
            //add case statement
            return 0;
        }
        
        public bool canUpgrade()
        {
            //if there is enough coins for each upgrade return true, else
          //  if (GameManager.instance.getBankAmount() >= getupgradeRequirement())
          //  {
           //     return true;
           // }
            return false;
        }

    }
}