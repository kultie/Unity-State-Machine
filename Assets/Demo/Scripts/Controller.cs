using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.StateMachine.Demo
{
    public class Controller : MonoBehaviour
    {
        StateMachine<DemoState, DemoContext> stateMachine;

        void Start()
        {
            stateMachine = new StateMachine<DemoState, DemoContext>(createStates());
            DemoContext context = new DemoContext
            {
                value = 1,
                stateMachine = stateMachine,
            };
            stateMachine.Change(DemoState.START, context);
        }

        Dictionary<DemoState, IState<DemoContext>> createStates()
        {
            Dictionary<DemoState, IState<DemoContext>> dic = new Dictionary<DemoState, IState<DemoContext>>();
            dic[DemoState.START] = new StartState();
            dic[DemoState.RUNNING] = new RunningState();
            dic[DemoState.STOP] = new StopState();
            return dic;
        }

        private void Update()
        {
            float dt = Time.deltaTime;
            stateMachine.Update(dt);
        }

    }

    public enum DemoState { START, RUNNING, STOP };

    public class DemoContext : StateContextBase
    {
        public float value;
        public StateMachine<DemoState, DemoContext> stateMachine;
    }

    public class StartState : StateBase<DemoContext>
    {
        protected override void OnEnter()
        {
            Debug.Log("Entering start state");
        }

        protected override void OnExit()
        {
            Debug.Log("Exiting start state");
        }

        protected override void OnUpdate(float dt)
        {
            Debug.Log("Updating Start state");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                context.stateMachine.Change(DemoState.RUNNING, context);
            }
        }
    }
    public class RunningState : StateBase<DemoContext>
    {
        protected override void OnEnter()
        {
            Debug.Log("Entering running state with value: " + context.value);
        }

        protected override void OnExit()
        {
            Debug.Log("Exiting running state");
        }

        protected override void OnUpdate(float dt)
        {
            Debug.Log("Updating running state");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                context.value = 5;
                context.stateMachine.Change(DemoState.STOP, context);
            }
        }
    }
    public class StopState : StateBase<DemoContext>
    {
        protected override void OnEnter()
        {
            Debug.Log("Entering stop state with value: " + context.value);
        }

        protected override void OnExit()
        {

        }

        protected override void OnUpdate(float dt)
        {

        }
    }

}