namespace MainMenu
{
    using UnityEngine;

    public class MainMenuSfx : MonoBehaviour
    {
        public static MainMenuSfx Instance;

        [SerializeField]
        private AudioClip[] BrightLifeBingo;
        [SerializeField]
        private AudioClip uiBlip;

        [SerializeField]
        private AudioSource voiceAudioSource;
        [SerializeField]
        private AudioSource uiAudioSource;

        private void Awake()
        {
            Instance = this;
        }

        public void Play_BrightLifeBingo()
        {
            voiceAudioSource.PlayOneShot(BrightLifeBingo[Random.Range(0, BrightLifeBingo.Length)]);
        }

        public void PlayUIConfirm() => uiAudioSource.PlayOneShot(uiBlip);
    }
}