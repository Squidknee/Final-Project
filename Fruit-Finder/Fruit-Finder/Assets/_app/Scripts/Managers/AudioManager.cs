using UnityEngine;

namespace _app.Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
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

        public void PlayAudio(AudioClip sound)
        {
            if (audioSource != null && sound != null)
            {
                audioSource.clip = sound;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource or AudioClip is not set!");
            }
        }
    }
}