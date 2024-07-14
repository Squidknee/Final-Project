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
        public int storageAmount ;
        public int playerWallet;
        public int bank;
        public TMP_Text backpackText;
        public TMP_Text bankText;

        public GameObject gameOver;
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

        public void AddToWalletMoney(int wallet)
        {
            playerWallet += wallet; 
            Debug.Log("wallet amount: "+ playerWallet);
            // I do not want money being displayed
        }
        public void AddToBankMoney()
        {
            //bank adds
            bank += playerWallet;
            //wallet empties
            playerWallet = 0;
            //backpack empties
            playerAmount = 0;
            //bank text gets updated
            bankText.text = ("Bank: " + bank.ToString());
        }

        public void upgrade()
        {
            //prompt the user to get either a backpack upgrade or a boots upgrade
             //check to see if they have enough resources
             //subtract fruit coins from bank
             //edit either storage or boots by what upgrades
            //not implemented yet
            Debug.Log("soon");
        }
        

        public int getPlayerAmount()
        {
            return playerAmount;
        }
        public int getBankAmount()
        {
            return bank;
        }
        public void winCondition()
        {
            if (bank >= 50)
            {
                gameOver.SetActive(true);
            }
        }
    }
}