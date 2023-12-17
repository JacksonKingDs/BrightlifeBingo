namespace MainGame
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    using MainGame.Audio;
    using MainGame.StateMachine;
    using Settings;
    using System.Collections;
    using VisualFeedback;

    /*
     Main menu uses MainMenu manager, this class is only used in the actual game.
     This holds a state machine, as well as a Session, which wraps around Boards, 
     Boards wrap around Cards. 
     */

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField]
        private MatchDetection matchDetection;

        [SerializeField]
        private GameSettings settings;

        [SerializeField]
        private Board[] boards;

        private GameSession session;
        private UIManager ui;
        private Sfx sfx;

        private StateMachineController stateMachine;
        private bool bingoAudioQueued = false;
        //Constant
        private const int MainMenuSceneIndex = 0;

        //Property
        public bool InPlayingMode => stateMachine.InPlayingMode;
        public MatchDetection MatchDetector => matchDetection;
        public int BingoCounts { get; private set; } = 0;

        #region Unity Events

        private void Awake()
        {
            Instance = this;

            matchDetection.init();
        }

        private void Start()
        {
            ui = UIManager.Instance;
            sfx = Sfx.Instance;

            stateMachine = new StateMachineController(this, settings);
            session = new GameSession(boards, settings, matchDetection);
        }

        private void Update()
        {
            stateMachine.OnUpdate();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoToMainMenu();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log(stateMachine.ActiveStateType);
            }
        }

        #endregion

        public void ClickedOnBingoButton()
        {
            sfx.Play_UI_Confirm();

            for (int i = 0; i < settings.NumberOfBingoCards; i++)
            {
                boards[i].BingoCheck();
            }
        }

        public void IncrementBingoScore()
        {
            BingoCounts++;
            UIManager.Instance.SetScore(BingoCounts);
            if (!bingoAudioQueued)
            {
                StartCoroutine(PlayBingoAudio());
            }
        }

        public void GoToMainMenu()
        {
            StartCoroutine(TransitionToMainMenu());
        }

        #region Private

        private IEnumerator StartSequence()
        {
            //UI display
            ui.StartCountDown();

            //Audio
            yield return new WaitForSeconds(0.2f);
            sfx.Play_AreYouReady();
            yield return new WaitForSeconds(1.2f);
            sfx.Play_GameStart();
        }

        private IEnumerator PlayBingoAudio()
        {
            //Avoid having multiple bingo triggered on the same frame.
            bingoAudioQueued = true;
            yield return null;
            sfx.Play_BingoFound();
        }

        private IEnumerator TransitionToMainMenu()
        {
            HoleFader fader = HoleFader.Instance;
            if (fader != null)
            {
                yield return new WaitForSeconds(1f);
            }
            SceneManager.LoadScene(MainMenuSceneIndex);
        }

        #endregion

        private GUIStyle myButtonStyle;
        private void OnGUI()
        {
            if (myButtonStyle == null)
            {
                myButtonStyle = new GUIStyle(GUI.skin.label)
                {
                    fontSize = 2000,
                    fontStyle = FontStyle.Bold
                };
            }

            GUI.Label(new Rect(20, 20, 2000, 500), "State " + stateMachine.ActiveStateType);
        }
    }
}