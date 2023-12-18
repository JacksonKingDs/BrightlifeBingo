namespace MainGame
{
    using System.Collections;

    using UnityEngine;
    using UnityEngine.SceneManagement;

    using MainGame.Audio;
    using Settings;
    using VisualFeedback;
    using MainGame.Audio;

    public class GameplayMB : MonoBehaviour
    {
        public static GameplayMB Instance;

        [SerializeField]
        private GameSettings settings;

        [Header("Gameplay")]
        [SerializeField]
        private MatchDetection matchDetection;

        [SerializeField]
        private Board[] boards;

        private UIManager ui;
        private Sfx sfx;
        private GameManager gm;

        public MatchDetection MatchDetector => matchDetection;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            ui = UIManager.Instance;
            sfx = Sfx.Instance;
            gm = GameManager.Instance;

            BoardArranger.Arrange(boards, settings, matchDetection);
        }

        public void ClickOnCard()
        {
            if (gm.CurrentState == GameStateTypes.Playing)
            {
                return;
            }

            sfx.Play_UI_Confirm();

            for (int i = 0; i < settings.NumberOfBingoCards; i++)
            {
                boards[i].BingoCheck();
            }
        }

        public void IncrementBingoScore()
        {
            gm.IncrementBingo();
            sfx.PlayBingo();
        }

        public void CheckMatch(bool[,] cardValues)
        {
            if (matchDetection.CheckMatch(cardValues))
            {
                IncrementBingoScore();
            }
        }
    }
}