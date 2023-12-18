namespace MainGame
{
    using System.Collections;

    using UnityEngine;
    using UnityEngine.SceneManagement;

    using MainGame.Audio;
    using Settings;
    using VisualFeedback;
    using MainGame.Audio;

    public class CountDownMB : MonoBehaviour
    {
        private UIManager ui;
        private Sfx sfx;
        private GameManager gm;

        private void Start()
        {
            ui = UIManager.Instance;
            sfx = Sfx.Instance;
            gm = GameManager.Instance;
        }

        public void StartCountDown()
        {
            StartCoroutine(StartSequence());
        }

        private IEnumerator StartSequence()
        {
            //UI display
            ui.StartCountDown();

            //Audio
            yield return new WaitForSeconds(0.2f);
            sfx.Play_AreYouReady();
            yield return new WaitForSeconds(1.2f);
            sfx.Play_GameStart();

            gm.StartGameplay();
        }
    }
}