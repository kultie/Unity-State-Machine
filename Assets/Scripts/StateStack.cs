using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.StateMachine
{
    public class StateStack : StateMachineBase
    {

        private List<IStateStackState> states;

        public StateStack() {
            states = new List<IStateStackState>();
        }

        public void Push(IStateStackState state, IStateContext context) {
            states.Add(state);
            state.Enter(context);
        }

        public IStateStackState Pop() {
            IStateStackState state = states[states.Count - 1];
            states.Remove(state);
            state.Exit();
            return state;
        }

        public IStateStackState Top() {
            if (states.Count > 0) {
                return states[states.Count - 1];
            }
            return null;
        }

        public void PopAll() {
            while (states.Count != 0) {
                Pop();
            }
        }

        public override void Update(float dt)
        {
            for (int i = states.Count - 1; i >= 0; i--) {
                IStateStackState state = states[i];
                state.Update(dt);
                bool isBlock = state.IsBlock();
                if (isBlock) {
                    break;
                }
            }

            if (states.Count == 0) {
                return;
            }
        }
    }

    public interface IStateStackState : IState
    {
        bool IsBlock();
    }
}