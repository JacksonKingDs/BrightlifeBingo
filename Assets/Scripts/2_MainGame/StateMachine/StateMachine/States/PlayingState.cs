namespace MainGame.StateMachine
{
    using System.Collections.Generic;
    using System.Collections;
    using UnityEngine;
    using VisualFeedback;
    using Settings;

    public class PlayingState : GameStates
    {
        #region Fields
        //References
        private UIManager uiManager;

        private float daubPercent;
        #endregion

        #region Initialization
        public PlayingState(StateMachineController stateMachine, GameManager gm, GameSettings settings) : base(stateMachine, gm, settings)
        {
        }
        #endregion

        #region State machine
        public override void OnEnter()
        {
        }

        public override void OnUpdate()
        {
            if (daubPercent < 1f)
            {
                SetDaubAmount(daubPercent + Time.deltaTime * settings.DaubMeterIncrementSpeed);
            }
        }

        public override void OnExit()
        {
            stateMachine.EnterState(GameStateTypes.GameOver);
        }
        #endregion

        private void SetDaubAmount(float amount)
        {
            daubPercent = Mathf.Clamp(amount, 0f, 1f);
            uiManager.SetDaubMeterFillAmount(daubPercent);
        }
    }
}