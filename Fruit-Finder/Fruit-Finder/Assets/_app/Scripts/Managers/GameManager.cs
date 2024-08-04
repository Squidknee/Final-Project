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
        
        public GameObject upgradeScreen;
        
        public int winAmount;
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject); // Destroy the duplicate instance
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
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

        public void showUpgrade()
        {
            upgradeScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public void upgrade(int deducted)
        {
            //bank subtracts
            bank -= deducted;
            //bank text gets updated
            bankText.text = ("Bank: " + bank.ToString());
        }
        
        public void closePanel()
        {
            upgradeScreen.SetActive(false);
            Cursor.visible = false; // This hides the cursor
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        public int getPlayerAmount()
        {
            return playerAmount;
        }
        public int getBankAmount()
        {
            return bank;
        }
        public int getStorageAmount()
        {
            return storageAmount;
        }

        public void setStorageAmount(int amnt)
        {
            storageAmount = amnt;
        }
        public void winCondition()
        {
            if (bank >= winAmount)
            {
                gameOver.SetActive(true);
            }
        }
    }
}