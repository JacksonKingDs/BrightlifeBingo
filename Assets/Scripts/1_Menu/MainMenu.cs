namespace MainMenu
{
    using System.Collections;

    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    using Settings;
    using TMPro;
    using MainGame.VisualFeedback;

    public class MainMenu : MonoBehaviour
    {
        /// <summary>
        /// Player selected settings from main menu gets carried into main game via settings.
        /// </summary>
        [Header("Component")]
        [SerializeField]
        private GameSettings settings; 

        [Header("UI - Bingo card count buttons")]
        [SerializeField] 
        private Button addBingoCardButton;

        [SerializeField] 
        private Button minusBingoCardButton;

        [SerializeField] 
        private TMP_Text bingoCardCountText;

        [Header("UI")]
        [SerializeField] 
        private GameObject playButton;
        
        [SerializeField] 
        private CanvasGroup mainMenuCanvasGroup;

        [SerializeField] 
        private CanvasGroup infoCanvasGroup;

        private MainMenuSfx sfx;
        private EventSystem eventSystem;
        private bool inTransition = false;

        private IEnumerator Start()
        {
            //Reference
            sfx = MainMenuSfx.Instance;
            eventSystem = EventSystem.current;

            //Set default selected button
            if (eventSystem.currentSelectedGameObject == null)
            {
                eventSystem.SetSelectedGameObject(playButton);
            }

            playButton.GetComponent<Selectable>().OnPointerEnter(null);

            //Initialize UI display of bingo card number
            SetBingoCardCount(settings.NumberOfBingoCards);

            yield return new WaitForSeconds(1f);
            
            sfx.Play_BrightLifeBingo();
        }

        public void BingoCardCountIncrease()
        {
            SetBingoCardCount(settings.NumberOfBingoCards + 1);
        }

        public void BingoCardCountDecrease()
        {
            SetBingoCardCount(settings.NumberOfBingoCards - 1);
        }

        public void OpenInfo()
        {
            if (inTransition)
            {
                return;
            }

            sfx.PlayUIConfirm();

            UIFadeUtil.SetCanvasToOpaque(infoCanvasGroup);
            UIFadeUtil.SetCanvasToTransparent(mainMenuCanvasGroup);
        }

        public void OpenMainMenu()
        {
            if (inTransition)
            {
                return;
            }

            sfx.PlayUIConfirm();

            UIFadeUtil.SetCanvasToTransparent(infoCanvasGroup);
            UIFadeUtil.SetCanvasToOpaque(mainMenuCanvasGroup);
        }

        public void OpenSite()
        {
            Application.OpenURL("https://www.brightlife.com.au/");
        }

        public void StartGame()
        {
            sfx.PlayUIConfirm();
            StartCoroutine(PlayFadeOutTransition());
        }

        private IEnumerator PlayFadeOutTransition()
        {
            HoleFader fader = HoleFader.Instance;
            if (fader != null)
            {
                inTransition = true;
                HoleFader.Instance.Close();
                yield return new WaitForSeconds(1f);
            }
            SceneManager.LoadScene(1);
        }

        private void SetBingoCardCount(int count)
        {
            if (inTransition)
            {
                return;
            }

            Debug.Log("settings.NumberOfBingoCards: " + settings.NumberOfBingoCards);
            count = Mathf.Clamp(count, 1, 4);

            //Add and minus buttons visibility
            minusBingoCardButton.interactable = (count != 1) ? true : false;
            addBingoCardButton.interactable = (count != 4) ? true : false;

            //Update ui text
            bingoCardCountText.text = count.ToString();

            //Update settings
            settings.NumberOfBingoCards = count;
            Debug.Log("settings.NumberOfBingoCards after: " + settings.NumberOfBingoCards);
        }
    }
}