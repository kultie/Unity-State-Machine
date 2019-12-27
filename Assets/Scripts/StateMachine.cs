using System.Collections.Generic;
namespace Kultie.StateMachine
{
    public class StateMachine : StateMachineBase
    {
        private Dictionary<string, IState> states;

        public IState currentState;

        public StateMachine(Dictionary<string, IState> states) {
            this.states = states;
        }

        public void Change(string name, IStateContext context) {
            if (!states.ContainsKey(name)) {
                return;
            }

            if (currentState != null) {
                currentState.Exit();
            }

            currentState = states[name];
            currentState.Enter(context);
        }

        public override void Update(float dt)
        {
            if (currentState != null) {
                currentState.Update(dt);
            }
        }
    }
}
