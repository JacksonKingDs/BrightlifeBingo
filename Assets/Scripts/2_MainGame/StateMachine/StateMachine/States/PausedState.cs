namespace MainGame.StateMachine
{
    using System.Collections;
    using UnityEngine;
    using Settings;

    public class PausedState : GameStates
    {
        public PausedState(StateMachineController stateMachine, GameManager gm, GameSettings settings) : base(stateMachine, gm, settings)
        {
        }

        public override void OnEnter() { }
        public override void OnUpdate() { }
        public override void OnExit()
        {
            stateMachine.EnterState(GameStateTypes.Playing);
        }
    }
}