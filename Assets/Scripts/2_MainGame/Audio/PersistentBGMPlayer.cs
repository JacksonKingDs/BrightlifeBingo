namespace Audio
{
    using UnityEngine;

    /// <summary>
    /// Persists between main menu scene and main game scene.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class PersistentBGMPlayer : MonoBehaviour
    {
        private static PersistentBGMPlayer instance;

        [SerializeField]
        private AudioSource audioSource;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}