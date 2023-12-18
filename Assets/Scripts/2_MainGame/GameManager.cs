namespace MainGame
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    using MainGame.Audio;
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
        private GameSettings settings;

        [Header("States")]
        [SerializeField]
        private CountDownMB countDownMB;

        [SerializeField]
        private GameplayMB gameplayMB;

        [SerializeField]
        private PausedMB pausedMB;

        [SerializeField]
        private GameOverMB gameOverMB;

        private UIManager ui;
        private Sfx sfx;

        private GameStateTypes currentState = GameStateTypes.Countdown;
        public GameStateTypes CurrentState => currentState;

        public int BingoCounts { get; private set; } = 0;

        #region Unity Events

        private void Awake()
        {
            Instance = this;
        }

        private IEnumerator Start()
        {
            ui = UIManager.Instance;
            sfx = Sfx.Instance;

            yield return null;

            currentState = GameStateTypes.Countdown;
            countDownMB.StartCountDown();
        }

        #endregion

        #region State change

        public void StartGameplay()
        {
            
        }

        #endregion

        #region Score

        public void IncrementBingo()
        {
            BingoCounts++;
            ui.SetScore(BingoCounts);
        }

        #endregion

        #region Private


        #endregion
    }
}