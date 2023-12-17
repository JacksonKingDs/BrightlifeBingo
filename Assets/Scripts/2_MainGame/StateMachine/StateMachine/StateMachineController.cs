
namespace MainGame.StateMachine
{
    using System.Collections;
    using UnityEngine;
    using Settings;

    public class StateMachineController
    {
        private GameStates countdownState;
        private GameStates playingState;
        private GameStates pausedState;
        private GameStates gameOverState;

        private GameStates activeState;
        private GameStateTypes activeStateType = GameStateTypes.Countdown;

        private GameManager gm;
        private GameSettings settings;

        public GameStateTypes ActiveStateType => activeStateType;
        public bool InPlayingMode => activeStateType == GameStateTypes.Playing;

        public StateMachineController(GameManager gm, GameSettings settings)
        {
            this.gm = gm;
            this.settings = settings;

            countdownState = new CoundownState(this, gm, settings);
            playingState = new PlayingState(this, gm, settings);
            pausedState = new PausedState(this, gm, settings);
            gameOverState = new GameOverState(this, gm, settings);

            activeState = countdownState;
            activeState.OnEnter();
        }

        public void OnUpdate()
        {
            activeState.OnUpdate();
        }

        public void EnterState(GameStateTypes newState)
        {
            Debug.Log("State change from " + activeState + " to " + newState);
            activeState.OnExit();
            activeStateType = newState;
            activeState = GetStateClass(newState);
        }

        public void ReturnToMainMenu()
        {
            gm.GoToMainMenu();
        }

        #region Util
        private GameStates GetStateClass(GameStateTypes state)
        {
            switch (state)
            {
                case GameStateTypes.Countdown:
                    return countdownState;
                case GameStateTypes.Playing:
                    return playingState;
                case GameStateTypes.Paused:
                    return pausedState;
                case GameStateTypes.GameOver:
                default:
                    return gameOverState;
            }
        }
        #endregion

    }
}