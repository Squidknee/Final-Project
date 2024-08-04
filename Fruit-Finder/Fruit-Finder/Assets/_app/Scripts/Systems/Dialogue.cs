using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
namespace _app.Scripts.Systems
{
    public class Dialogue : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;
        public string[] lines;
        public float textSpeed;

        private int index;
        void Start()
        {
            textComponent.text = string.Empty;
            StartDialogue();
        }

        void Update()
        {
            //if user clicks left mouse button, auto fill line
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }

        void StartDialogue()
        {
            index = 0;
            StartCoroutine(TypeLine());
        }
        
        //coroutine 
        IEnumerator TypeLine()
        {
            //takes each letter and displays it 
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        void NextLine()
        {
            //if there are still lines left 
            if (index < lines.Length - 1)
            {
                //move to the next line
                index++;
                //set the current string to be empty
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                gameObject.SetActive(false);
                SceneManager.LoadSceneAsync("SampleScene");
            }
        }
    }
}