namespace MainGame
{
    using System.Collections;

    using UnityEngine;
    using UnityEngine.SceneManagement;

    using MainGame.Audio;
    using Settings;
    using VisualFeedback;


    public class PausedMB : MonoBehaviour
    {
        private const int MainMenuSceneIndex = 0;

        private IEnumerator TransitionToMainMenu()
        {
            HoleFader fader = HoleFader.Instance;
            if (fader != null)
            {
                yield return new WaitForSeconds(1f);
            }
            SceneManager.LoadScene(MainMenuSceneIndex);
        }
    }
}