namespace MainGame.StateMachine
{
    using System.Collections;
    using UnityEngine;
    using VisualFeedback;
    using Settings;

    public class CoundownState : GameStates
    {
        private UIManager uiManager;
        private WaitForSeconds sequenceDuration = new WaitForSeconds(2f);


        public CoundownState(StateMachineController stateMachine, GameManager gm, GameSettings settings) : base(stateMachine, gm, settings)
        {
            uiManager = UIManager.Instance;
        }

        
        public override void OnEnter()
        {
            //StartCoroutine(StartGameSequence());
        }

        private IEnumerator StartGameSequence()
        {
            uiManager.StartCountDown();
            yield return sequenceDuration;

            OnExit();
        }

        public override void OnUpdate() { }
        public override void OnExit() 
        {
            stateMachine.EnterState(GameStateTypes.Playing);
        }
    }
}

