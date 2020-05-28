using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.StateMachine.Behavior;
public class HelloState : StateComponent
{
    public override string ID => "Hello";
    float currentTime;

    public override void OnEnter(StateMachineComponent stateMachine, StateContextComponent context)
    {
        Debug.Log(GetContext<DemoContext>(context).sentence);
        currentTime = 0;
    }

    public override void OnExit(StateMachineComponent stateMachine, StateContextComponent context)
    {
        Debug.Log("Done greeting time for dinner date");
    }

    public override void OnUpdate(StateMachineComponent stateMachine, StateContextComponent context)
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 2) {
            GetContext<DemoContext>(context).sentence = "Currently dating";
            stateMachine.ChangeState("Dating");
        }
    }
}
