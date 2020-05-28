using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.StateMachine.Behavior
{
    public class StateMachineComponent : MonoBehaviour
    {
        public StateContextComponent context;
        public Transform stateContainer;
        private Dictionary<string, StateComponent> _states = new Dictionary<string, StateComponent>();
        StateComponent currentState;
        string currentStateID;
        private void Start()
        {
            StateComponent[] states = stateContainer.GetComponents<StateComponent>();
            string defaultId = string.Empty;
            for (int i = 0; i < states.Length; i++)
            {
                _states[states[i].ID] = states[i];
                if (states[i].isDefault)
                {
                    defaultId = states[i].ID;
                }
            }
            ChangeState(defaultId);
        }

        private void Update()
        {
            if (currentState != null)
            {
                currentState.OnUpdate(this, context);
            }
        }

        public void ChangeState(string id)
        {
            if (currentState != null)
            {
                currentState.OnExit(this, context);
            }
            currentStateID = string.Empty;
            currentState = null;
            if (!_states.TryGetValue(id, out currentState))
            {
                Debug.Log("State with " + id + " is not existed");
            }
            currentStateID = id;
            currentState.OnEnter(this, context);

        }
    }
}