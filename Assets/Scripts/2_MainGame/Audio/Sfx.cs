namespace MainGame.Audio
{
    using System.Collections;

    using UnityEngine;

    [RequireComponent(typeof(AudioSource))]
    public class Sfx : MonoBehaviour
    {
        public static Sfx Instance;

        [Header("Audio Source")]
        [SerializeField] 
        private AudioSource uiAudioSource;
        
        [SerializeField] 
        private AudioSource voiceAudioSource;

        [Header("Audio clips")]
        [SerializeField] 
        private AudioClip confirmSound;
        
        [SerializeField] 
        private AudioClip levelCompleteSound;
        
        [SerializeField] 
        private AudioClip areYouReady;
        
        [SerializeField] 
        private AudioClip gameStart;
        
        [SerializeField] 
        private AudioClip[] bingoFound;

        private bool bingoAudioQueued = false;

        private void Awake()
        {
            Instance = this;
        }

        //Game events
        public void Play_AreYouReady() => VoicePlay(areYouReady);
        public void Play_GameStart() => VoicePlay(gameStart);
        public void Play_GameComplete() => VoicePlay(levelCompleteSound);

        //General UI
        public void Play_UI_Confirm() => UIPlay(confirmSound);

        //Gameplay
        public void PlayBingo()
        {
            if (!bingoAudioQueued)
            {
                StartCoroutine(WaitToPlayBingo());
            }
        }

        private IEnumerator WaitToPlayBingo()
        {
            //Avoid multiple bingos in the same frame triggering multiple sfx.
            bingoAudioQueued = true;
            yield return null;
            VoicePlay(bingoFound[Random.Range(0, bingoFound.Length)]);
        }


        #region Audio source play   

        private void VoicePlay(AudioClip clip) => voiceAudioSource.PlayOneShot(clip);
        private void UIPlay(AudioClip clip) => uiAudioSource.PlayOneShot(clip);

        #endregion
    }
}