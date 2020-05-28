using Kultie.StateMachine.Behavior;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodbyState : StateComponent
{
    public override string ID => "Goodbye";

    public override void OnEnter(StateMachineComponent stateMachine, StateContextComponent context)
    {
        Debug.Log(GetContext<DemoContext>(context).sentence);
        Debug.Log("Done");
    }

    public override void OnExit(StateMachineComponent stateMachine, StateContextComponent context)
    {

    }

    public override void OnUpdate(StateMachineComponent stateMachine, StateContextComponent context)
    {

    }
}
