namespace MainGame.StateMachine
{
    using System.Collections;
    using UnityEngine;
    using Settings;

    public class GameOverState : GameStates
    {

        public GameOverState(StateMachineController stateMachine, GameManager gm, GameSettings settings) : base(stateMachine, gm, settings)
        {
        }

        public override void OnEnter() 
        { 
            //TODO: Show score board
        }

        public override void OnUpdate() { }
        public override void OnExit()
        {
            stateMachine.ReturnToMainMenu();
        }
    }
}