namespace MainGame.StateMachine
{
    using Settings;

    public abstract class GameStates
    {
        protected GameManager gm;
        protected GameSettings settings;
        protected StateMachineController stateMachine;

        public GameStates(StateMachineController stateMachine, GameManager gm, GameSettings settings)
        {
            this.gm = gm;
            this.settings = settings;
        }

        public virtual void OnEnter() { }
        public virtual void OnUpdate() { }
        public virtual void OnExit() { }
    }
}