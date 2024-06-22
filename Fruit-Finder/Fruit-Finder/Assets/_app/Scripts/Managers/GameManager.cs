using TMPro;
using UnityEngine;

namespace _app.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        //how much the player is holding
        public int playerAmount;
        //how much storage is available
        public int storageAmount;
        public int playerWallet;
        public TMP_Text backpackText;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy((this));
            }
            else
            {
                instance = this;
            }
        }
        
        public void ChangeStorageAmount(int holdingAmount)
        {
            playerAmount += holdingAmount;
            backpackText.text = ("Storage: " + playerAmount.ToString() + "/" + storageAmount);
        }

        public void ChangeMoney(int wallet)
        {
            playerWallet += wallet; 
            // I do not want money being displayed
        }
    
    }
}