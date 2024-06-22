using UnityEngine;

namespace _app.Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        public AudioClip audio;
        public AudioSource audioSource;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        public void PlayAudio()
        {
            if (audioSource != null && audio != null)
            {
                audioSource.clip = audio;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource or AudioClip is not set!");
            }
        }
    }
}