using System;
using System.Collections;
using _app.Scripts.Managers;
using UnityEditor.Build.Content;
using UnityEngine;

namespace _app.Scripts.Triggers
{
   public class Fruits : MonoBehaviour
   {
      [SerializeField] [Header("Quantitative Data")]
      //what the fruit amount will be in the backpack (usually 1 but always good to keep open for the possibility of change)
      public int countAmount;

      //fruit worth when sold
      public int worth;

      [Header("Qualitative Data")]
      //what type of fruit (Apple, Banana, etc)
      public string fruitType;

      //what world fruit can spawn in
      public ArrayList spawnLocation;

      public void OnTriggerEnter(Collider other)
      {
         if (other.CompareTag("Player"))
         {
            if (AudioManager.instance != null && GameManager.instance != null)
            {
               //if the backpack is not full
               AudioManager.instance.PlayAudio();
               GameManager.instance.ChangeStorageAmount(countAmount);
               GameManager.instance.ChangeMoney(worth);
               Destroy(gameObject);
            }
            else
            {
               Debug.Log(other.transform.name + " Entered Trigger, no AudioManager or GameManager");
               
               
            }
         }
         else
         {
            Debug.Log("Entered but not a player");
         }
      }
      public void OnTriggerExit(Collider other)
      {
         Debug.Log(other.transform.name + " Exited Trigger");
      }
   }
}