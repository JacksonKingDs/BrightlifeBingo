namespace MainMenu
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class UIManager : MonoBehaviour
    {
        #region Fields
        [Space(10)]
        [Header("Animator")]
        public Animator menuAnimator;
        public Animator aboutAnimator;

        [Space(10)]
        [Header("UI Buttons")]
        [SerializeField] GameObject menu_Button_Play;
        [SerializeField] GameObject menu_Button_About;
        [SerializeField] GameObject menu_Button_Quit;

        [SerializeField] GameObject About_Button_Back;

        //Reference class
        EventSystem eventSystem;
        MainMenuSfx sfx;

        //Menu state
        bool menuActive = true;
        #endregion

        #region Monobehavior
        void Awake()
        {
            //Init
            Cursor.visible = true;

            //Fade in menu canvas group
            menuAnimator.Play("FadeIn");
        }

        void Start()
        {
            //Class reference
            sfx = MainMenuSfx.Instance;

            //Initialize
            eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(menu_Button_Play);

            if (eventSystem.currentSelectedGameObject == null)
                eventSystem.SetSelectedGameObject(menu_Button_Play);
            menu_Button_Play.GetComponent<Selectable>().OnPointerEnter(null);
        }

        #endregion

        // MENU BUTTONS
        public void ButtonClick_BackToMain()
        {
            if (menuActive)
            {
                sfx.PlayUIConfirm();
            }
        }

        public void ButtonClick_Play()
        {
            if (menuActive)
            {
                menuActive = false;
                sfx.PlayUIConfirm();
            }
        }

        public void ButtonClick_ToAbout()
        {
            if (menuActive)
            {
                sfx.PlayUIConfirm();
            }
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}