using _app.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace _app.Scripts.Triggers
{
    public class InteractionCircle : MonoBehaviour
    {
        public TMP_Text backpackText;
        public TMP_Text bankText;
        private bool entered = false;
        public AudioClip cashRegister;

        public void OnTriggerEnter(Collider other)
        {
            if (entered == false)
            {
                if (other.CompareTag("Player"))
                {
                    //flag entered set to true
                    entered = true;
                    //if flag is true, allow interaction with E
                    
                    if (GameManager.instance != null)
                    {
                        //backpack empties
                        int playerAmount = GameManager.instance.getPlayerAmount();
                        if (playerAmount != 0)
                        {
                            AudioManager.instance.PlayAudio(cashRegister);
                            backpackText.text = ("Storage: 0/20");
                            GameManager.instance.AddToBankMoney();
                            GameManager.instance.winCondition();
                        }
                        //TODO
                        //if the player clicks the E button
                       // if (Input.GetKeyDown(KeyCode.E))
                       // {
                            // Call the method to handle the interaction
                        //    GameManager.instance.upgrade();
                        //}
                    }
                    else
                    {
                        Debug.Log(other.transform.name + " Entered Trigger, no GameManager");
                    }
                }
                else
                {
                  //  Debug.Log("Entered but not a player");
                }
            }
        }
        
        public void OnTriggerExit(Collider other)
        {
            entered = false;
            Debug.Log(other.transform.name + " Exited Trigger");
        }
    }
}