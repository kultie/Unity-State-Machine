using System.Collections.Generic;
namespace Kultie.StateMachine
{
    public class StateMachine<T> : StateMachineBase<T> where T: IStateContext
    {
        private Dictionary<string, IState<T>> states;

        public IState<T> currentState;

        public StateMachine(Dictionary<string, IState<T>> states) {
            this.states = states;
        }

        public void Change(string name, T context) {
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
