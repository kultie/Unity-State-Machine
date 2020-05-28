using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.StateMachine.Behavior
{
    public abstract class StateComponent : MonoBehaviour
    {
        public abstract string ID { get; }
        public bool isDefault;
        public abstract void OnUpdate(StateMachineComponent stateMachine, StateContextComponent context);
        public abstract void OnEnter(StateMachineComponent stateMachine, StateContextComponent context);
        public abstract void OnExit(StateMachineComponent stateMachine, StateContextComponent context);
        protected T GetContext<T>(StateContextComponent context) where T : StateContextComponent
        {
            return context as T;
        }
    }
}