using System.Collections;
using System.Collections.Generic;
using _app.Scripts.Managers;
using _app.Scripts.Player;
using _app.Scripts.Triggers;
using UnityEngine;
using UnityEngine.UI;
namespace _app.Scripts.Systems
{
    public class Upgrade : MonoBehaviour
    {
        //button arrays for unlocking 
        public Button[] storageButtons;
        public Button[] spawningButtons;
        public Button[] jumpButtons;
        public Button[] moveButtons;
        
        //player object 
        public PlayerMovement player;
        
        //random spawner
        public RandomSpawner spawner;

        public GameObject funds; 
        public AudioClip error;
        
        private List<Button[]> allButtons = new List<Button[]>();
        private Dictionary<string, int> indexMap = new Dictionary<string, int>();
        private Dictionary<string, int> upgradeCost = new Dictionary<string, int>();
        
        private void Awake()
        {
            //add buttons to button list
            allButtons.Add(storageButtons);
            allButtons.Add(spawningButtons);
            allButtons.Add(jumpButtons);
            allButtons.Add(moveButtons);
            
            //start map off at 0 for each 
            indexMap.Add("Storage", 0);
            indexMap.Add("Spawn", 0);
            indexMap.Add("Jump", 0);
            indexMap.Add("Move", 0);
            
            //set each cost to be even 
            upgradeCost.Add("Storage", 10);
            upgradeCost.Add("Spawn", 10);
            upgradeCost.Add("Jump", 10);
            upgradeCost.Add("Move", 10);

            UnlockFirstButtonInEachArray();
        }
        
        void UnlockFirstButtonInEachArray()
        {
            foreach (Button[] buttonArray in allButtons)
            {
                Debug.Log("unlocked");
                if (buttonArray.Length > 0)
                {
                    //setting interactable to true
                    buttonArray[0].interactable = true;
                    changeDisabledColor(buttonArray[0]);
                }
            }
        }
        
        public void upgrade(string key)
        {
            Debug.Log("Clicked");
            if (upgradeCost.TryGetValue(key, out int currUpgradeCost))
            {
                //if there is enough money in the bank
                if (GameManager.instance.getBankAmount() >= currUpgradeCost)
                {
                    switch (key)
                    {
                        case "Storage":
                            int currStorage = GameManager.instance.getStorageAmount();
                            currStorage += 10; 
                            GameManager.instance.setStorageAmount(currStorage);
                            break;
                        case "Spawn":
                            //change spawn time to be faster
                            spawner.spawnInterval -= 5f;
                            break;
                        case "Jump":
                            player.jumpForce += new Vector3(0, 12, 0);;
                            break;
                        case "Move":
                            player.moveSpeed += 10f;
                            break;
                    }
                    
                    //subtract money from bank 
                    GameManager.instance.upgrade(currUpgradeCost);
                    
                    //Update upgrade cost for the next index
                    upgradeCost[key] = currUpgradeCost + 10; //Update cost logic later if needed
                    
                    // Update index map
                    if (indexMap.ContainsKey(key))
                    {
                        indexMap[key]++;
                    }
                    
                    // Unlock the next button in the array
                    UnlockNextButton(key);
                }
                else
                {
                    ShowInsufficientFunds();
                    AudioManager.instance.PlayAudio(error);
                }
            }
            else
            {
                Debug.LogWarning($"No upgrade cost found for key: {key}");
            }
        }
        
        private void ShowInsufficientFunds()
        {
            funds.SetActive(true);
            StartCoroutine(CloseInsufficientFundsAfterDelay(3f)); // Wait for 3 seconds before hiding
        }

        private IEnumerator CloseInsufficientFundsAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            funds.SetActive(false); // Hide the insufficient funds message
        }
        
        void UnlockNextButton(string key)
        {
            if (indexMap.TryGetValue(key, out int index))
            {
                Button[] buttonArray = null;
                switch (key)
                {
                    case "Storage":
                        buttonArray = storageButtons;
                        break;
                    case "Spawn":
                        buttonArray = spawningButtons;
                        break;
                    case "Jump":
                        buttonArray = jumpButtons;
                        break;
                    case "Worth":
                        buttonArray = moveButtons;
                        break;
                }

                if (buttonArray != null && index < buttonArray.Length)
                {
                    buttonArray[index].interactable = true;
                    buttonArray[index - 1].interactable = false;
                    changeDisabledColor(buttonArray[index]);
                }
            }
        }
        
        //once the button is set to active, keep the disabled color the active color
        void changeDisabledColor(Button button)
        {
            ColorBlock colorBlock = button.colors;
            colorBlock.disabledColor = colorBlock.normalColor;
            button.colors = colorBlock;
        }
    }
}